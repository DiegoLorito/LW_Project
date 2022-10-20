using UnityEngine;

[CreateAssetMenu(fileName = "TP Whack it", menuName = "Scriptable Objects/Template/TP Whack it")]
public class SO_TemplateWhackIt : SO_Template
{
    [Header("Tutorial")]
    public AudioClip clipTutorial;

    [Header("Reinforcement")]
    public bool hasReinforcement;
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public SO_VocabWhackIt[] vocabulary;
}
