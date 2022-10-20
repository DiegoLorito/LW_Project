using UnityEngine;

public class SpotTrophy : MonoBehaviour
{
    public UnityEngine.UI.VerticalLayoutGroup layout;

    private void Awake()
    {
        layout = GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
    }
}
