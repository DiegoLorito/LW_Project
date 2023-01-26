using System.Collections.Generic;
using UnityEngine;

public class DataContentCore : PersistentSingleton<DataContentCore>
{
    [SerializeField] private SO_ContentGroup _data;

    [Space(10)]
    public int amountContent;
    public int amountNormalChest;
    public int amountSpecialChest;

    public Dictionary<string, SO_ContentCore> Data => _data.Data;

    public void SetContentData()
    {
        _data.SetData();

        foreach (var value in Data.Values)
        {
            switch (value.category)
            {
                case Enm_ContentCategory.Content:
                    amountContent++;
                    break;
                case Enm_ContentCategory.NormalChest:
                    amountNormalChest++;
                    break;
                case Enm_ContentCategory.SpecialChest:
                    amountSpecialChest++;
                    break;
                default:
                    break;
            }
        }

    }

}
