using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Catalog Worlds", menuName = "Scriptable Objects/Catalogs/Catalog Worlds")]
public class SO_DataWorlds : ScriptableObject
{
    [SerializeField] private SO_WorldCore[] data;

    public Dictionary<string, SO_WorldCore> Data;

    public void Initialize()
    {
        Data = new Dictionary<string, SO_WorldCore>();

        for (int i = 0; i < data.Length; i++)
        {
            string key = data[i].code;

            if (Data.ContainsKey(key))
            {
                Debug.LogWarning($"{key} ya existe en el diccionerio de MUNDOS");
                continue;
            }

            Data.Add(key, data[i]);
        }
    }
}
