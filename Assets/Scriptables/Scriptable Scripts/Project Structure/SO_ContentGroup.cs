using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Content Group", menuName = "Scriptable Objects/App Sctructure/Content Group")]
public class SO_ContentGroup : ScriptableObject
{
    [SerializeField] private SO_ContentCore[] data;

    public Dictionary<string, SO_ContentCore> Data;

    public List<string> dataCodes
    {
        get
        {
            if (Data == null)
            {
                //return null;
                SetData();
            }

            return new List<string>(Data.Keys);
        }
    }
    public List<SO_ContentCore> dataValues
    {
        get
        {
            if (Data == null)
            {
                //return null;
                SetData();
            }

            return new List<SO_ContentCore>(Data.Values);
        }
    }

    public void SetData()
    {
        Data = new Dictionary<string, SO_ContentCore>();

        for (int i = 0; i < data.Length; i++)
        {
            Data.Add(data[i].code, data[i]);
        }
    }
}
