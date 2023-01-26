using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new unit", menuName = "Scriptable Objects/Data Unit")]
public class UnitData : ScriptableObject
{
    [Header("Identifiers")]
    public int index;

    [Header("Core")]
    public SO_UnitCore core;

    [Space(10)]
    [Header("Sprites")]
    public Sprite icon;
    public Sprite background;
    public Sprite thumbnail;

    [Space(10)]
    [Header("Vocabulary")]
    public List<VocabularyGroupData> dataVocabulary;

    [Space(10)]
    [Header("Phrases")]
    public List<PhraseData> dataPhrases;

    [Space(10)]
    [Header("Content")]
    public List<ContentData> dataContent;

    [HideInInspector] public int totalGames;
    [HideInInspector] public int totalVideos;
    [HideInInspector] public int totalContent;

    public void GetTotalContent() 
    {
        int games = 0;
        int videos = 0;

        for (int i = 0; i < dataContent.Count; i++)
        {    
            switch (dataContent[i].type)
            {
                case ContentData.Type.game:
                    games++;
                    break;
                case ContentData.Type.video:
                    videos++;
                    break;
                case ContentData.Type.episode:
                    videos++;
                    break;
            }
        }

        totalGames = games;
        totalVideos = videos;
        totalContent = totalGames + totalVideos;
    }
    public ContentData GetContent(string code)
    {
        ContentData data = dataContent.Find(x => x.code == code);

        if(data == null)
        {
            return dataContent[0];
        }
        else
        {
            return data;
        }
    }
}
