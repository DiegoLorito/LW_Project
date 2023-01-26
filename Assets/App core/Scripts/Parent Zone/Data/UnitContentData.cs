using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitDetails
{
    public int id;
    public string code;
    public Color colorBackground;
    public Color colorMiddleground;
    public Sprite icon;
    public Sprite thumbnail;
    public Sprite middleground;

    [TextArea(5,50)]
    public string description;

    [Space(20)]
    public UnitSections sections;

    private UnitDetails unitDetails;

    public UnitDetails(UnitDetails unitDetails)
    {
        this.unitDetails = unitDetails;
    }
}

[System.Serializable]
public class UnitSections
{
    public List<UnitGroupContentData> vocabulary;
    public List<CardContentPhrasesData> phrases;
}

[System.Serializable]
public class UnitContentData
{
    public string name;
    public Sprite icon;
    public AudioClip sound;
}


[System.Serializable]
public class UnitGroupContentData
{
    public string groupName;
    public List<UnitContentData> content;
}

