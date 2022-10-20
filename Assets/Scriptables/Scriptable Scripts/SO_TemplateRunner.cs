using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Runner", menuName = "Scriptable Objects/Template/TP Runner")]
public class SO_TemplateRunner : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public List<Sprite> vocab;
    public List<Sprite> vocabUI;
    public List<AudioClip> clipVocab;

    [Header("Personaje")]
    public GameObject personaje;

}
