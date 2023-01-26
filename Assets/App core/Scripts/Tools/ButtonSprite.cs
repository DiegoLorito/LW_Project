using UnityEngine;
using UnityEngine.Events;

public class ButtonSprite : MonoBehaviour
{
    public bool interactable = true;
    public SpriteRenderer icon;

    [Space(10)]
    public UnityEvent onClick;

    [HideInInspector] public UnityEvent onMouseDown;
    [HideInInspector] public UnityEvent onMouseHold;
    [HideInInspector] public UnityEvent onMouseUp;

    private bool mouseDown;

    private new BoxCollider2D collider;

    private void Awake()
    {
        GameEvents.onButtonsSpriteInteractable += ButtonInteractable;

        if(TryGetComponent(out BoxCollider2D col))
        {
            col = gameObject.GetComponent<BoxCollider2D>();
        }
        else
        {
            col = gameObject.AddComponent<BoxCollider2D>();
        }

        this.collider = col;
        this.collider.isTrigger = true;
    }

    private void OnEnable()
    {
        GameEvents.onButtonsSpriteInteractable += ButtonInteractable;
    }
    private void OnDisable()
    {
        GameEvents.onButtonsSpriteInteractable -= ButtonInteractable;
    }

    private void Update()
    {
        if (mouseDown) onMouseHold?.Invoke();
    }

    private void OnMouseDown()
    {
        if (!interactable) return;

        mouseDown = true;
        onMouseDown?.Invoke();
    }
    private void OnMouseUp()
    {
        if (!interactable) return;

        mouseDown = false;
        onMouseUp?.Invoke(); 
    }

    //=== Si el jugador hace click
    private void OnMouseUpAsButton()
    {
        if (interactable && onClick != null)
        {
            onClick.Invoke();
        }
    }

    public void TestButton() => Debug.Log($"Button {name} is working");
    private void ButtonInteractable(bool value)
    {
        interactable = value;
        collider.enabled = value;
    }

    private void OnDestroy()
    {
        GameEvents.onButtonsSpriteInteractable -= ButtonInteractable;
    }


}
