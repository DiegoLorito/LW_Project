
public class DialogWorlds : DialogCustom
{
    //[UnityEngine.HideInInspector]
    public UserData data;

    public CardWorld[] items;

    public override void Init()
    {
        for (int i = 0; i < items.Length; i++)
        {
            //items[i].data = CatalogWorlds.instance.data[i];
            items[i].data = new WorldData() ;
            //items[i].data.id = CatalogWorlds.Instance.data[i].id;
        }
    }
    public override void SetData()
    {
        EnableItemsCheck();
    }
    public void SelectItem(CardWorld card)
    {
        data.worldId = card.data.id;
        EnableItemsCheck();
    }
    public void EnableItemsCheck()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].EnableCheck(data.worldId);
        }
    }
}
