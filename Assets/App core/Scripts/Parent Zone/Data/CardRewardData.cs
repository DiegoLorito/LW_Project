using System;
using UnityEngine;

[System.Serializable]
public class CardRewardData
{
    public int id;

    public Sprite icon;
    public string Name;
    public string code;
    public System.DateTime date;

    public CardRewardData(RewardData data = null)
    {
        if (data == null) return;

        //this.id = data.id_rewards_collected;
        this.Name = data.Name;
        this.code = data.code;
        this.date = data.date;
        this.icon = data.icon;
    }
}
