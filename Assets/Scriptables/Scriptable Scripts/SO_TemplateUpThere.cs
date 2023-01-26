using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Upthere", menuName = "Scriptable Objects/Template/TP UpThere")]
public class SO_TemplateUpThere : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("General")]
    public Sprite spBackground;
    public GameObject objNave;
    public AudioClip clipTuto;
    //public Sprite spBoat;

    [Header("Vocabulary")]
    public List<Sprite> sprtGame; 
    public List<string> Phrase;
    public List<AudioClip> audioClip;
    public List<Sprite> sprtUI;
}
