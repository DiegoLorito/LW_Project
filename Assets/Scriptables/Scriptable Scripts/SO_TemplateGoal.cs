using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Goal", menuName = "Scriptable Objects/Template/TP Goal")]
public class SO_TemplateGoal : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public List<string> wordVocab;
    public List<Sprite> sprtVocab;
    public List<AudioClip> clipVocab;
}
