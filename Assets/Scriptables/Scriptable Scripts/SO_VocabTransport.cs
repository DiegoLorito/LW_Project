
using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Loritransport", menuName = "Scriptable Objects/Vocabulary/Vocab Loritransport")]
public class SO_VocabTransport : SO_Vocabulary
{
    [Header("Text")]
    [SerializeField] private string strReinforcement;

    [Header("Sprites")]
    public bool isHorizontal;

    [SerializeField] private Sprite spIcon;
    [SerializeField] private Sprite spReinforcement;

    [Header("Audios")]
    [SerializeField] private AudioClip clipVocabIcon;
    [SerializeField] private AudioClip clipReinforcement;

    public override string StrVocab => strReinforcement;
    public override string StrReinforcement => strReinforcement;
    public override Sprite Icon => spIcon;
    public override Sprite SpVocab => spReinforcement;
    public override AudioClip ClipVocab => clipVocabIcon;
    public override AudioClip ClipReinforcement => clipReinforcement;
}
