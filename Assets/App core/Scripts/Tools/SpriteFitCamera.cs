using UnityEngine;


public class SpriteFitCamera : MonoBehaviour
{
    private SpriteRenderer _spRender;
    private Bounds _totalBounds;

    public Bounds TotalBounds { get => _totalBounds; private set => _totalBounds = value; }

    [SerializeField] private SpriteDrawMode _drawMode = SpriteDrawMode.Sliced;
    [SerializeField] private bool fitPositionX = false;
    [SerializeField] private bool fitPositionY = false;

    private void Awake()
    {
        _spRender = GetComponent<SpriteRenderer>();

        _spRender.drawMode = _drawMode;

        _totalBounds = _spRender.bounds;

        if (fitPositionX) transform.SetPosX(Helper.Camera.transform.position.x);
        if (fitPositionY) transform.SetPosY(Helper.Camera.transform.position.y);

        SetSpriteBounds();
    }



    public void SetSpriteBounds()
    {
        float _cameraSizeX = Helper.Camera.OrthographicBounds().size.x;
        float _cameraSizeY = Helper.Camera.OrthographicBounds().size.y;

        float _spRendersizeX = _spRender.bounds.size.x;
        float _spRendersizeY = _spRender.bounds.size.y;

        if(_cameraSizeY > _spRendersizeY)
        {
            _spRender.size = new Vector2(_spRendersizeX, _cameraSizeY);

            _totalBounds = _spRender.bounds;
        }

        if (_cameraSizeX > _spRendersizeX)
        {
            Vector3 newBounds = new Vector3(_spRender.bounds.size.x * 3, _spRender.bounds.size.y,_spRender.bounds.size.z);

            _totalBounds.size = newBounds;

            GameObject spObjectRight = new GameObject();
            GameObject spObjectLeft = new GameObject();

            SpriteRenderer _spRight = spObjectRight.AddComponent<SpriteRenderer>();
            SpriteRenderer _spLeft = spObjectLeft.AddComponent<SpriteRenderer>();

            SetSpriteRenderClone(_spRight);
            SetSpriteRenderClone(_spLeft);

            _spRight.transform.position = (Vector2)_spRight.transform.position + (Vector2.right * _spRendersizeX);
            _spLeft.transform.position = (Vector2)_spLeft.transform.position - (Vector2.right * _spRendersizeX);

            void SetSpriteRenderClone(SpriteRenderer spRender)
            {
                //spRender = _spRender.GetComponent<SpriteRenderer>();

                spRender.sprite = _spRender.sprite;
                spRender.sortingOrder = _spRender.sortingOrder;
                spRender.drawMode = _drawMode;
                spRender.size = _spRender.size;
                spRender.transform.parent = transform;
                spRender.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (TotalBounds == null) return;

        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, TotalBounds.extents * 2);
    }
}
