using System.Collections.Generic;
using UnityEngine;

public class SO_DataUnits : MonoBehaviour
{
    [SerializeField] private SO_UnitCore[] data;

    public Dictionary<string, SO_UnitCore> Data;

    public void Initialize()
    {
        Data = new Dictionary<string, SO_UnitCore>();

        for (int i = 0; i < data.Length; i++)
        {
            Data.Add(data[i].code, data[i]);
        }
    }
}
