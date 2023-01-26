using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Spelling", menuName = "Scriptable Objects/Template/TP Spelling")]
public class SO_TemplateSpelling : SO_Template
{
    [Header("SCRAMBLE")]
    public bool scramble;

    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public List<string> word;
    public List<Sprite> vocab;
    public List<AudioClip> clipCorrecto;
    public bool sprtTransparente;

}
