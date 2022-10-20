using UnityEngine;
using UnityEngine.UI;

public class CardContentPhrases : MonoBehaviour
{
    [HideInInspector] public PhraseData data;

    public Text spanish;
    public Text english;

    public void SetData()
    {
        spanish.text = data.traduction;
        english.text = data.original;
    }
}
