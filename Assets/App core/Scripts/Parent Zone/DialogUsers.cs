using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUsers : DialogCustom
{
    public List<UserData> data;

    public CardUser[] items;
    private int usersCount = 0;

    public override void Init()
    {
        if (data == null) data = new List<UserData>();

        data.Clear();
        

        UpdateCards();
    }
    public override void SetData()
    {
        if (usersCount != AppServerData.instance.users.Count)
        {
            UpdateCards();
        }
        else
        {
            EnableItemsCheck();
        }
    }
    public void SelectItem(UserData user)
    {
        AppServerData.instance.dataCurrentUser = user;

        //ParentZoneEvents.ReloadSection();
        //ParentZoneEvents.UpdateAvatarIcon();

        EnableItemsCheck();
        controller.HideCustomDialog(gameObject);
    }
    public void EnableItemsCheck()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].EnableCheck();
        }
    }
    private void UpdateCards()
    {
        data = AppServerData.instance.users;

        items.EnableItemList(false);

        for (int i = 0; i < data.Count; i++)
        {
            UserData aux = data[i];

            items[i].gameObject.SetActive(true);
            items[i].data = data[i];
            items[i].SetData();

            items[i].button.onClick.RemoveAllListeners();
            items[i].button.onClick.AddListener(()=> SelectItem(aux));
        }

        usersCount = data.Count; 
    }
}
