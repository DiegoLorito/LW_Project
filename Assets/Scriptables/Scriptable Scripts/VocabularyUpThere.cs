using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new unit", menuName = "Scriptable Objects/Data UpThere")]
public class VocabularyUpThere : VocabularyData
{
    public Sprite sprtGame; /*{ get; private set; }*/
    public List<string> Phrase;
    public List<AudioClip> audioClip;
    public List<Sprite> sprtUI;

}
