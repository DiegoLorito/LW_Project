using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Stack", menuName = "Scriptable Objects/Template/TP Stack")]
public class SO_TemplateStack : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public List<Sprite> vocab;
    public List<AudioClip> clipVocab;
    public bool checkOrder;

}
