using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardActivityData
{
    public Sprite icon;
    public string title;
    public string world;
    public string number;
    public Color bgColor;

    public CardActivityData(ContentData data = null)
    {
        if (data == null) return;

        this.icon = data.icon;
        this.title = data.Name;
    }
}
