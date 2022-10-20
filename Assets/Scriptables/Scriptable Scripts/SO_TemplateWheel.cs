using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Wheel", menuName = "Scriptable Objects/Template/TP Wheel")]
public class SO_TemplateWheel : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public List<string> wordVocab;
    public List<Sprite> sprtVocab;
    public List<AudioClip> clipVocab;
}
