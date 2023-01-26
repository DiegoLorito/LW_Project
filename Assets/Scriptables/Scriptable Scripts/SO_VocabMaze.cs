using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Maze", menuName = "Scriptable Objects/Vocabulary/Vocab Maze")]
public class SO_VocabMaze : SO_Vocabulary
{
    [Header("Text")]
    [SerializeField] private string strReinforcement;

    [Header("Sprites")]
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
