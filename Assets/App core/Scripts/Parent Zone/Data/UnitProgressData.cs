using UnityEngine;

[System.Serializable]
public class UnitProgressData
{
    public UnitData unitData;
    public float totalProgress;
    public float currenProgress;

    public UnitProgressData(UnitData unitData)
    {
        this.unitData = unitData;
        totalProgress = unitData.dataContent.Count;
    }
}
