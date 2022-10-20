using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Catalog Thumbnails", menuName = "Scriptable Objects/Catalogs/Catalog Thumbnails")]
public class SO_DataTemplates : ScriptableObject 
{
    [SerializeField] private SO_TemplateData[] data;

    public Dictionary<string, SO_TemplateData> Data;

    public void Initialize()
    {
        Data = new Dictionary<string, SO_TemplateData>();

        for (int i = 0; i < data.Length; i++)
        {
            Data.Add(data[i].code, data[i]);
        }
    }
}
