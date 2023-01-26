using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Group", menuName = "Scriptable Objects/App Sctructure/Unit Group")]
public class SO_UnitGroup : ScriptableObject
{
    [SerializeField] private SO_UnitCore[] data;

    public Dictionary<string, SO_UnitCore> Data;

    public List<string> dataCodes
    {
        get
        {
            if(Data == null)
            {
                //return null;
                SetData();
            }

            return new List<string>(Data.Keys);
        }
    }
    public List<SO_UnitCore> dataValues
    {
        get
        {
            if (Data == null)
            {
                //return null;
                SetData();
            }

            return new List<SO_UnitCore>(Data.Values);
        }
    }



    public void SetData()
    {
        Data = new Dictionary<string, SO_UnitCore>();

        for (int i = 0; i < data.Length; i++)
        {
            Data.Add(data[i].code, data[i]);
        }
    }
}
