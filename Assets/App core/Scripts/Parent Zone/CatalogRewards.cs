using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogRewards : MonoBehaviour
{
    public static CatalogRewards instance;

    public static List<RewardData> staticData;
    public List<RewardData> data;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        staticData = data;
    }
    public static RewardData GetRewardByCode(string code)
    {
        return staticData.Find(x => x.code == code);
    }
}
