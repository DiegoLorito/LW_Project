using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Fishing", menuName = "Scriptable Objects/Vocabulary/Vocab Fishing")]
public class SO_VocabFishing : SO_Vocabulary
{
    [Header("Texts")]
    [SerializeField] private string _strVocab;
    //[SerializeField] private string strIcon;

    [Header("Sprites")]
    [SerializeField] protected Sprite _spReinforcement;
    [SerializeField] protected Sprite _spIcon;

    [Header("Audios")]
    [SerializeField] protected AudioClip _clipVocabIcon;
    [SerializeField] protected AudioClip _clipReinforcement;


    public override string StrVocab => _strVocab;
    public override Sprite SpVocab => _spReinforcement;
    public override Sprite Icon => _spIcon;

    public override AudioClip ClipVocab => _clipVocabIcon;
    public override AudioClip ClipReinforcement => _clipReinforcement;
}
 