using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Loricards", menuName = "Scriptable Objects/Template/TP Loricards")]
public class SO_TemplateLoricard : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulario")]
    public List<Sprite> icons;
    public List<string> word;
    public List<AudioClip> clip;
}
