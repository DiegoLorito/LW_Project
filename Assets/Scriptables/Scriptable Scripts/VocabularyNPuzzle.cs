using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new unit", menuName = "Scriptable Objects/Data NPuzzle")]
public class VocabularyNPuzzle : VocabularyData
{
    public List<GameObject> objNPuzzle;
    public GameObject objPos;
    public List<string> vocabNPuzzle;
    public List<AudioClip> clipNPuzzle;
    public List<int> correctRound;
}
