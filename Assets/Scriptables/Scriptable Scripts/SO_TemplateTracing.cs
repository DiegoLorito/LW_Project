using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Tracing", menuName = "Scriptable Objects/Template/TP Tracing")]
public class SO_TemplateTracing : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("TIPO")]
    public bool letter;

    [Header("Vocabulario")]
    public string word;
    public Sprite sprtVocab;
    public AudioClip clipVocab;
    public GameObject objTracing;
    public AudioClip cliptutorial;

}
