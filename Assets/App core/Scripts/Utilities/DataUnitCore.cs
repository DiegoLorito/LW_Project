using System.Collections.Generic;

public class DataUnitCore : PersistentSingleton<DataUnitCore>
{
    public SO_UnitGroup data;

    protected override void Awake()
    {
        base.Awake(); //TEMP
        data.SetData();
    }

    public Dictionary<string, SO_UnitCore> Data => data.Data;
}
