using UnityEngine;

[CreateAssetMenu(fileName = "new vocabulary data", menuName = "Scriptable Objects/Data Vocabulary")]
public class VocabularyData : ScriptableObject
{
    public Sprite[] icons;
    public string word;
    public string InCorrectWord;
    public AudioClip clip;
    public AudioClip clipCorrecto;
    public AudioClip auIncorrecto;
    public Color color = Color.white;
    public int valCorrect;

    public Sprite MainIcon => icons[0];
}
