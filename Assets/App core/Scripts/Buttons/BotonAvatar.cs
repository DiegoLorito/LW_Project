using UnityEngine;
using UnityEngine.UI;

public class BotonAvatar : MonoBehaviour
{
    public int id;
    public Image icon;

    //private Button button;

    private void Awake()
    {
        //button = GetComponent<Button>();
        //button.onClick.AddListener(SelectAvatar);
        GetComponent<Button>().onClick.AddListener(SelectAvatar);
    }

    private void SelectAvatar()
    {
        LocalSavedData.SetAvatarId(id);
        GameEvents.SetAvatarSprite(icon.sprite);
    }
}
