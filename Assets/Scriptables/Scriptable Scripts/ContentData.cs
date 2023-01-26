using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new content", menuName = "Scriptable Objects/Data Content")]
public class ContentData : SO_ContentCore
{
    public enum Type { game, video, episode }

    public string Name;
    public Sprite icon;
    public Type type;

    public List<SO_LoriItem> rewards;
    public List<VocabularyData> vocabulary;    
    public List<PhraseData> phrases;
    public List<PeanutsHFV> PeanutsHfv;
    public List<ScriptableObject> obj;

    [Header("Assets")]
    public string templateCode;
    public string assetsCode;

    public bool HasReward
    {
        get
        {
            if (rewards != null && rewards.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
