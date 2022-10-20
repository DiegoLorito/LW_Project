using UnityEngine;

[CreateAssetMenu(fileName = "TP Loritransport", menuName = "Scriptable Objects/Template/TP Loritransport")]
public class SO_TemplateLoritransport : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Space(10)]
    [Header("General")]
    public GameObject objCharacter;
    public bool isConsecutive;
    public bool isParrots;
    public int totalToCollect;

    [Space(10)]
    [Header("Enviroment")]
    public Color backgroundColor;
    public Sprite spBackground;
    public Sprite spBounds;

    public GameObject groupDecoration;
    public GameObject groupItems;

    [Header("Vocabulary")]
    public SO_VocabTransport[] vocabulary;
}



