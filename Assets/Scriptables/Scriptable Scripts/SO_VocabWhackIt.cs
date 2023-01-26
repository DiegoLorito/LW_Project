
using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Whack It", menuName = "Scriptable Objects/Vocabulary/SO_VocabWhackIt")]
public class SO_VocabWhackIt : SO_Vocabulary
{
    [Header("Sprites")]
    [SerializeField] private Sprite spVocab;
    [SerializeField] private Sprite spIcon;

    [Header("Audios")]
    [SerializeField] private AudioClip clipVocabIcon;
    [SerializeField] private AudioClip clipReinforcement;

    [Header("General")]
    public int amount;
    public Enm_WhackItQuiz groupType;


    public override Sprite SpVocab => spVocab;
    public override AudioClip ClipVocab => clipVocabIcon;
    public override AudioClip ClipReinforcement => clipReinforcement;
    public override Sprite Icon => spIcon;
}
