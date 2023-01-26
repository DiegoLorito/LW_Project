using UnityEngine;

[CreateAssetMenu(fileName ="TP Fishing", menuName = "Scriptable Objects/Template/TP Fishing")] 
public class SO_TemplateFishing : SO_Template
{
    [Header("Tutorial")]
    public AudioClip clipTutorial;

    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("General")]
    public Sprite spBackground;
    public Sprite spCharacter;
    public Sprite spBoat;

    [Header("Vocabulary")]
    public SO_VocabFishing[] vocabulary;
}
