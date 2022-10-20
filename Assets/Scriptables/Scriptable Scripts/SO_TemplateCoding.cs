using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Coding", menuName = "Scriptable Objects/Template/TP Coding")]
public class SO_TemplateCoding : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("PERSONAJE")]
    public GameObject chartCoding;

    [Header("Vocabulary")]
    public List<string> word;
    public List<Sprite> icon;
    public List<Sprite> iconUI;
    public List<AudioClip> clipCorrecto;
    public List<AudioClip> clipUI;

}
