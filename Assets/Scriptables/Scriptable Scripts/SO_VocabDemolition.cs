using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Demolition", menuName = "Scriptable Objects/Vocabulary/Vocab Demolition")]
public class SO_VocabDemolition : SO_Vocabulary
{
    [Header("Sprites")]
    [SerializeField] private Sprite spIcon;

    [Header("Audios")]
    [SerializeField] private AudioClip clipVocabIcon;
    [SerializeField] private AudioClip clipReinforcement;
    [SerializeField] private AudioClip clipIncorrect;

    public override Sprite SpVocab => spIcon;
    public override Sprite Icon => spIcon;
    public override AudioClip ClipVocab => clipVocabIcon;
    public override AudioClip ClipReinforcement => clipReinforcement;
    public override AudioClip ClipIncorrect => clipIncorrect;


}
