using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Skate", menuName = "Scriptable Objects/Vocabulary/Vocab Skate")]
public class SO_VocabSkate : SO_Vocabulary
{
    [Header("Text")]
    [SerializeField] private string strVocab;

    [Header("Sprites")]
    [SerializeField] private Sprite spVocab;

    [Header("Audios")]
    [SerializeField] private AudioClip clipVocabIcon;

    public override string StrVocab => strVocab;
    public override Sprite Icon => spVocab;
    public override Sprite SpVocab => spVocab;
    public override AudioClip ClipVocab => clipVocabIcon;
}
