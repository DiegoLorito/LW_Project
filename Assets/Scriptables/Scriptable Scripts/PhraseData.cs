
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new phrase data", menuName = "Scriptable Objects/Data Phrase")]
public class PhraseData : ScriptableObject
{
    public string traduction;
    public string original;
    public AudioClip clip; 
}
