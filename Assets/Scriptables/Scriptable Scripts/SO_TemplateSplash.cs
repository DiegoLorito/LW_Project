using UnityEngine;

[CreateAssetMenu(fileName = "TP Splash", menuName = "Scriptable Objects/Template/TP Splash")]
public class SO_TemplateSplash : SO_Template
{
    [Header("Reinforcement")]
    public bool hasReinforcement = true;
    public bool hasText;
    public bool hasCharacter;

    [Header("General")]
    public Sprite spCharacter;

    public bool isConsecutive;
    public GameObject objDecorationGroup;

    //=== Máximo 2 grupos ===//
    public GameObject[] objItemGroups;


    [Header("Vocabulary")]
    public SO_VocabSplash[] vocabulary;
}
