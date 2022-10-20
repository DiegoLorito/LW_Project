using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Toss It", menuName = "Scriptable Objects/Template/TP Toss It")]
public class So_TemplateTossIt : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulario")]
    public List<GameObject> playerLanza;
    public List<GameObject> playerCesto;
    public List<Sprite> vocab;
    public List<Sprite> vocabPopUp;
    public List<string> oracionVocab;
    public List<AudioClip> clipVocab;
    public List<string> oracionPopUp;
    public List<AudioClip> clipPopUp;
    public List<int> orderLanza;
    public List<int> orderCesto;
    public List<AudioClip> clipRisa;
    public List<AudioClip> clipOuch;

}
