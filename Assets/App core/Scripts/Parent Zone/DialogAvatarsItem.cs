using UnityEngine;

public class DialogAvatarsItem : MonoBehaviour
{
    [HideInInspector] public DialogAvatars dialog;

    public UnityEngine.UI.Image icon;
    public GameObject check;

    public void EnableCheck()
    {
        check.SetActive(icon.sprite == dialog.avatar.sprite);
    }
}
