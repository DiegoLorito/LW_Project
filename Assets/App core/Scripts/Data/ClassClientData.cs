using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClassClientData
{
    public int id;
    public string name;

    //public Dictionary<int,int> userAvatars = new Dictionary<int, int>();
    public List<DictionaryInts> userAvatars = new List<DictionaryInts>();
}


[System.Serializable]
public struct DictionaryInts
{
    public int int1;
    public int int2;
}