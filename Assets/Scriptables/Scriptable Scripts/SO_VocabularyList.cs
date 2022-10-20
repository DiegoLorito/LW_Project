using UnityEngine;


[CreateAssetMenu(fileName = "Vocab list", menuName = "Scriptable Objects/Vocabulary/Vocab List", order = 0)]
public class SO_VocabularyList : ScriptableObject
{
    public SO_Vocabulary[] vocabulary;
    public int Lenght => vocabulary.Length;
}
