using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new vocabulary group data", menuName = "Scriptable Objects/Data Vocabulary Group")]
public class VocabularyGroupData : ScriptableObject
{
    public string Name;
    public List<VocabularyData> data; 
}
