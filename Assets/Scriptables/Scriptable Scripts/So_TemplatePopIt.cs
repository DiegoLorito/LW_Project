using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Pop It", menuName = "Scriptable Objects/Template/TP Pop It")]
public class So_TemplatePopIt : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulario")]
    public List<string> oracionVocab;
    public List<Sprite> vocab;
    public List<AudioClip> clipVocab;
}
