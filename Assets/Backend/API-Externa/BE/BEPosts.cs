using System;

[Serializable]
public class BEPosts
{
    public int post_id;
    public string title;
    public bool has_likes;
    public int count_likes;
    public string image_url;
    public string link;
    public string date_created;
    public string date_updated;
}
