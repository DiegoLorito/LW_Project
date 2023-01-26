using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new world", menuName = "Scriptable Objects/Data World")]
public class WorldData: ScriptableObject
{
    public int id; 
    public string Name;
    public string code;
    public int minAge;
    public int maxAge;
    public Sprite icon;
    public Color color;

    public List<UnitData> units;

    [HideInInspector] public int totalGames;
    [HideInInspector] public int totalVideos;
    [HideInInspector] public int totalContent;


    public void GetTotalContent()
    {
        totalGames = 0;
        totalVideos = 0;
        totalContent = 0;

        for (int i = 0; i < units.Count; i++)
        {
            units[i].GetTotalContent();

            totalGames += units[i].totalGames;
            totalVideos += units[i].totalVideos;
            totalContent += units[i].totalContent;
        }
    }
    public UnitData GetUnit(string code)
    {
        UnitData data = units.Find(x => x.core.code == code);

        if (data) return data;

        return units[0];
    }
    public UnitData GetUnitByIndex(int index)
    {
        return units.Find(x => x.index == index);
    }
}
