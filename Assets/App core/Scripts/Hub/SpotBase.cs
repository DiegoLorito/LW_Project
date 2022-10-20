using UnityEngine;

public class SpotBase : MonoBehaviour
{
    protected UnityEngine.UI.VerticalLayoutGroup _layout;
    [SerializeField] protected UnityEngine.UI.Button button;

    public UnityEngine.UI.VerticalLayoutGroup Layout
    {
        get
        {
            return _layout;
        }
        set
        {
            _layout = value;
        }
    }

    public virtual void SetData() { }
}
