using UnityEngine;

[CreateAssetMenu(fileName = "TP Skate", menuName = "Scriptable Objects/Template/TP Skate")]
public class SO_TemplateSkate : SO_Template
{
    [Header("Tutorial")]
    public AudioClip clipTutorial;

    [Header("Music")]
    public AudioClip clipBackground;

    [Header("General")]
    public GameObject character;
    public Sprite spBackground;
    public Sprite spGround;
    public GameObject[] objOstacles;

    [Header("Vocabulary")]
    public SO_VocabSkate[] vocabulary;
}
