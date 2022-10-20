using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour
{
    public GameObject prefItem;
    public CheckListItemData[] itemsData;

    private List<CheckListItem> listItems;

    public void Awake()
    {
        listItems = new List<CheckListItem>();

        for (int i = 0; i < itemsData.Length; i++)
        {
            CheckListItem item = Instantiate(prefItem, transform).GetComponent<CheckListItem>();
            item.data = itemsData[i];

            listItems.Add(item);
            listItems[i].Init();
        }
    }
    public void SetItemStatus(int index, bool status)
    {
        if(index > listItems.Count)
        {
            print("Index Item Checklist fuera de rango");
            return;
        }

        listItems[index].SetActiveIcon(status);
    }
    public bool isComplete()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            if (!listItems[i].data.completed) return false;
        }

        return true;
    }
}
