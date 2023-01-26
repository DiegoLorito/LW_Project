using UnityEngine;

[CreateAssetMenu(fileName = "Item Sticker", menuName = "Scriptable Objects/Reward/Sticker")]
public class SO_Sticker : SO_LoriItem
{
    [Space(10)]
    public Sprite empty;
    public Sprite fill;

    public Sprite character;
    public string nameCharacter;

    [Header("Vocabulary")]
    public VocabularyData[] vocabulary;
}
