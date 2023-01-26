using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Jumpy Path", menuName = "Scriptable Objects/Template/TP Jumpy Path")]
public class So_TemplateJumpyPath : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Personaje")]
    public GameObject chart;
    public float chartScale;

    [Header("Vocabulary")]
    public List<string> word;
    public List<Sprite> icons;
    public List<AudioClip> clipCorrecto;
    public Sprite pointFinal;

}
