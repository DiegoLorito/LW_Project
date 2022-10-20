
public class DialogAvatars : DialogCustom
{
    [UnityEngine.HideInInspector] public UserData data;

    public UnityEngine.UI.Image avatar;
    public DialogAvatarsItem[] items;

    public override void Init()
    {
        for (int i = 0; i < items.Length; i++)
        {
            print("Revisar Comentario");
            //SO_Avatar avatarData = CatalogAvatars.instance.data[i];

            //items[i].dialog = this;
            //items[i].icon.sprite = avatarData.icon;
        }
    }
    public override void SetData()
    {
        avatar.sprite = data.Avatar.icon;
        EnableItemsCheck();
    }

    public void SelectAvatar(int id)
    {
        avatar.sprite = items[id].icon.sprite;
        EnableItemsCheck();
    } 
    public void EnableItemsCheck()
    { 
        for (int i = 0; i < items.Length; i++)
        {
            items[i].EnableCheck();
        }
    }
}
