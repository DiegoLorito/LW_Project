using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new unit", menuName = "Scriptable Objects/Data TossIt")]
public class VocabularyTossIt : VocabularyData
{
    public List<Sprite> vocab;
    public List<Sprite> vocabPopUp;
    public List<string> oracionVocab;
    public List<AudioClip> clipVocab;
    public List<string> oracionPopUp;
    public List<AudioClip> clipPopUp;
    public List<GameObject> playerLanza;
    public List<GameObject> playerCesto;
    public List<int> orderLanza;
    public List<int> orderCesto;
    public List<AudioClip> clipRisa;
    public List<AudioClip> clipOuch;

}
