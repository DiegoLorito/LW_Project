using UnityEngine;

[System.Serializable]
public class CardNewsData 
{
    public int id;

    [Header("Card")]
    public Texture thumbnail;
    public System.DateTime date;
    public string title;
    public int likesAmount;
    public bool liked;
    public string link;
    public string imageUrl;

    public CardNewsData(BEPosts data = null)
    {
        if (data == null) return;

        this.id = data.post_id;
        this.date = System.DateTime.Parse(data.date_updated);
        this.title = data.title;
        this.likesAmount = data.count_likes;
        this.liked = data.has_likes; 
        this.link = data.link;
        this.imageUrl = data.image_url;
    }
}
