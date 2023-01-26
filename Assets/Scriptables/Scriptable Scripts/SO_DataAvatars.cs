using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Catalog Avatars", menuName = "Scriptable Objects/Catalogs/Catalog Avatars")]
public class SO_DataAvatars : ScriptableObject
{
    [SerializeField] private SO_Avatar[] data;

    public Dictionary<string, SO_Avatar> Data;

    //public List<SO_Avatar> values => new List<SO_Avatar>(Data.Values);

    public void Initialize()
    {
        Data = new Dictionary<string, SO_Avatar>();

        for (int i = 0; i < data.Length; i++)
        {
            string key = data[i].code;

            if (Data.ContainsKey(key))
            {
                Debug.LogWarning($"{key} ya existe en el diccionerio de AVATARS");
                continue;
            }

            Data.Add(key, data[i]);
        }
    }
}
