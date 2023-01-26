using UnityEngine;

public class SpotChest : MonoBehaviour
{
    public UnityEngine.UI.VerticalLayoutGroup layout;
    private void Awake()
    {
        layout = GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
    }
}
