using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Pin It", menuName = "Scriptable Objects/Template/TP Pin It")]
public class So_TemplatePinIt : SO_Template
{
    [Header("Vocabulario")]
    public List<string> oracionVocab;
    public List<Sprite> vocab;
    public List<AudioClip> clipVocab;
    public List<AudioClip> clipIncorrect;

    [Header("Personajes")]
    public List<GameObject> personajes;

}
