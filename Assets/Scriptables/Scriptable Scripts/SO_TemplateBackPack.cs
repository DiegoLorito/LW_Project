using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP BackPack", menuName = "Scriptable Objects/Template/TP BackPack")]
public class SO_TemplateBackPack : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;
    [Header("General")]
    public GameObject personaje;
    public Sprite backGround;

    [Header("Vocabulary")]
    public List<string> word;
    public List<Sprite> icons;
    public List<AudioClip> clipCorrecto;

}
