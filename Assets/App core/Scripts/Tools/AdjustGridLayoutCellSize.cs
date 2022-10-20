using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
[RequireComponent(typeof(GridLayoutGroup))]
public class AdjustGridLayoutCellSize : MonoBehaviour
{
    public enum Axis { X, Y };
    public enum RatioMode { Free, Fixed };
    public enum Expand { cell, space };

    [SerializeField] Axis expand;
    [SerializeField] RatioMode ratioMode;
    [SerializeField] float cellRatio = 1;
    [SerializeField] Expand type;

    RectTransform rect;
    public GridLayoutGroup grid;
    void Awake()
    {
        rect = (RectTransform)base.transform;
        grid = GetComponent<GridLayoutGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (type == Expand.cell)
            UpdateCellSize();
        else if (type == Expand.space)
            UpdateCellSpace();
    }
    void OnRectTransformDimensionsChange()
    {
        if (type == Expand.cell)
            UpdateCellSize();
        else if (type == Expand.space)
            UpdateCellSpace();
    }
#if UNITY_EDITOR
    [ExecuteAlways]
    void Update()
    {
        if (type == Expand.cell)
            UpdateCellSize();
        else if (type == Expand.space)
            UpdateCellSpace();
    }
#endif
    void OnValidate()
    {
        rect = (RectTransform)base.transform;
        grid = GetComponent<GridLayoutGroup>();
        if (type == Expand.cell)
            UpdateCellSize();
        else if (type == Expand.space)
            UpdateCellSpace();
    }
    void UpdateCellSize()
    {
        var count = grid.constraintCount;
        if (expand == Axis.X)
        {
            if (rect == null) return;

            float spacing = (count - 1) * grid.spacing.x;
            float contentSize = rect.rect.width - grid.padding.left - grid.padding.right - spacing;
            float sizePerCell = contentSize / count;
            grid.cellSize = new Vector2(sizePerCell, ratioMode == RatioMode.Free ? grid.cellSize.y : sizePerCell * cellRatio);

        }
        else //if (expand == Axis.Y)
        {
            float spacing = (count - 1) * grid.spacing.y;
            float contentSize = rect.rect.height - grid.padding.top - grid.padding.bottom - spacing;
            float sizePerCell = contentSize / count;
            grid.cellSize = new Vector2(ratioMode == RatioMode.Free ? grid.cellSize.x : sizePerCell * cellRatio, sizePerCell);
        }
    }

    void UpdateCellSpace()
    {
        var count = grid.constraintCount;
        if (expand == Axis.X)
        {

            float contentSize = count * grid.cellSize.x;
            float spacing = rect.rect.width - grid.padding.left - grid.padding.right - contentSize;
            float spacePerCell = Mathf.Clamp(spacing / (count + 1), 0, grid.cellSize.x / 2.0f);
            grid.spacing = new Vector2(spacePerCell, ratioMode == RatioMode.Free ? grid.spacing.y : spacePerCell * cellRatio);

        }
        else //if (expand == Axis.Y)
        {
            float contentSize = count * grid.cellSize.y;
            float spacing = rect.rect.height - grid.padding.top - grid.padding.bottom - contentSize;
            float spacePerCell = Mathf.Clamp(spacing / (count + 1), 0, grid.cellSize.y / 2.0f);
            grid.spacing = new Vector2(ratioMode == RatioMode.Free ? grid.spacing.x : spacePerCell * cellRatio, spacePerCell);
        }
    }
}