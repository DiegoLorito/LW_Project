using UnityEngine;

[System.Serializable]
public class ClassContentData
{
    public enum Type {game, video, episode }

    public int id;
    public int index;
    public string code; 
    public string name;
    public Sprite icon;
    public Type type;
    public bool completed;

    //public ClassContentData(int _id, string _code)
    //{
    //    this.id = _id;
    //    this.code = _code;
    //}
}
