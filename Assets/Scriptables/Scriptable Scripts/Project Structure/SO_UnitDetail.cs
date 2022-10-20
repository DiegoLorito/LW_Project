using UnityEngine;

[CreateAssetMenu(fileName = "Unit Details", menuName = "Scriptable Objects/App Sctructure/Unit Details")]
public class SO_UnitDetail : ScriptableObject
{
    [TextArea(5, 5)]
    public string description;

    [Space(10)]
    [Header("Vocabulary")]
    public VocabularyGroupData[] dataVocabulary;

    [Space(10)]
    [Header("Phrases")]
    public PhraseData[] dataPhrases;
}
