using System;

[Serializable]
public class BEPurchasedAvatarItems
{
    public int id_purchased_avatar_items;
    public int id_user_account;
    public string str_avatar_item_code;
    public DateTime dte_creation_date;

    public BEPurchasedAvatarItems(int id_purchased_avatar_items, int id_user_account, string str_avatar_item_code,  DateTime dte_creation_date)
    {
        this.id_purchased_avatar_items = id_purchased_avatar_items;
        this.id_user_account = id_user_account;
        this.str_avatar_item_code = str_avatar_item_code;
        this.dte_creation_date = dte_creation_date;
    }
}
