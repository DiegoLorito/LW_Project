using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Bricks", menuName = "Scriptable Objects/Template/TP Bricks")]
public class SO_TemplateBricks : SO_Template
{
    [Header("Vocabulary")]
    public List<string> word;
    public List<Sprite> icon1;
    public List<Sprite> icon2;
    public List<AudioClip> clipCorrecto;
    public List<AudioClip> clipUI;

    [Header("Personaje")]
    public GameObject personaje;

}
