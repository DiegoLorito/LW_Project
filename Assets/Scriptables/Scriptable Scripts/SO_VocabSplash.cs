using UnityEngine;

[CreateAssetMenu(fileName = "Vocab Splash", menuName = "Scriptable Objects/Vocabulary/SO_VocabSplash")]
public class SO_VocabSplash : SO_Vocabulary
{
    public Enm_SplashEnemyType type;
    [Range(1,2)]
    public int amount;

    [Space(10)]
    [Header("Text")]
    [SerializeField] private string strVocab;
    [SerializeField] private string strReinforcement;

    [Header("Sprites")]
    [SerializeField] private Sprite spIcon;
    [SerializeField] private Sprite spPipeline;
    [SerializeField] private Sprite spReinforcement;

    [Header("Audios")]
    [SerializeField] private AudioClip clipVocabIcon;
    [SerializeField] private AudioClip clipReinforcement;
    [SerializeField] private AudioClip clipIncorrect;



    //=================================================
    public override string StrVocab => strVocab;
    public override string StrReinforcement => strReinforcement;
    public override Sprite Icon => spIcon;
    public override Sprite SpVocab => spReinforcement;
    public override AudioClip ClipVocab => clipVocabIcon;
    public override AudioClip ClipReinforcement => clipReinforcement;
    public override AudioClip ClipIncorrect => clipIncorrect;

    public Sprite SpPipeline => spPipeline;
}
