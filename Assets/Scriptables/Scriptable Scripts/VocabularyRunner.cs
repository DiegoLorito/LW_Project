using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new unit", menuName = "Scriptable Objects/Data Runner")]
public class VocabularyRunner : VocabularyData
{
    public List<Sprite> vocab;
    public List<Sprite> vocabUI;
    public List<AudioClip> clipVocab;

}
