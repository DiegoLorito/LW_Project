using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardNewsDetailData
{
    public bool liked;
    public string description;

    public CardNewsDetailData(BEPostContent data)
    {
        this.liked = data.has_likes;
        this.description = data.content;
    }
}
