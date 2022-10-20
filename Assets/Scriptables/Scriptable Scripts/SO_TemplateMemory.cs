using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Memory", menuName = "Scriptable Objects/Template/TP Memory")]
public class SO_TemplateMemory : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Setup")]
    public bool macaws;

    [Header("Vocabulary")]
    public List<string> word;
    public List<Sprite> icons;
    public List<AudioClip> clipCorrecto;
   
}
