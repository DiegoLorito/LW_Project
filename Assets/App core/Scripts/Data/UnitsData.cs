using System.Collections.Generic;
using UnityEngine;

public class UnitsData : MonoBehaviour
{
    public static UnitsData instance;

    [Header("Units Core Data")]
    public List<SO_UnitCore> dataUnitsCore;

    [Header("Units List")]
    public List<UnitProgressData> data;

    [Header("Unit Details")]
    public UnitData dataContent;

    [HideInInspector] public UnitData currentCard;


    //=== TEMP
    private SO_UnitCore _currentUnit; 


    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        //ParentZoneEvents.onUnitsResumeDataLoaded += SetUnitResumeDataList;
        //ParentZoneEvents.onUnitDetailsDataLoaded += SetUnitDetails;
    }

    public void SetDataUnitsCore()
    {
        Debug.Log("Cargamos la data de Units Core desde Addressables");
    }
    public void SetUnitResumeDataList(ResponsePZUnitReport response = null)
    {
        if (data == null) data = new List<UnitProgressData>();

        data.Clear();

        //WorldData world = AppServerData.instance.dataCurrentUser.GetWorld();
        WorldData world = new WorldData();

        for (int i = 0; i < world.units.Count; i++)
        {
            data.Add(new UnitProgressData(world.units[i]));
        }

        if (response.data == null) return;

        for (int i = 0; i < response.data.Length; i++)
        {
            for (int j = 0; j < data.Count; j++)
            {
                if (data[j].unitData.core.code == response.data[i].str_unit_code)
                {
                    data[j].currenProgress = response.data[i].int_finished_contents;
                    break;
                }
            }
        }

    }
    public void SetUnitDetails()
    {
        dataContent = currentCard;
    }
    private void OnDestroy() 
    {
        //ParentZoneEvents.onUnitsResumeDataLoaded -= SetUnitResumeDataList;
        //ParentZoneEvents.onUnitDetailsDataLoaded -= SetUnitDetails;
    }


    public SO_UnitCore CurrentUnit
    {
        get
        {
            if (!_currentUnit)
            {
                _currentUnit = AppServerData.instance.dataCurrentUser.CurrentUnit;
            }

            return _currentUnit;
        }
        set
        {
            _currentUnit = value;
        }
    }
    public SO_UnitCore GetUnitCoreByCode(string code)=> dataUnitsCore.Find((x)=> x.code == code);
}
