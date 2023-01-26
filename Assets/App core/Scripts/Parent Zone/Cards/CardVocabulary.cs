using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVocabulary : MonoBehaviour
{
    [HideInInspector] public VocabularyData data;

    public Image icon;
    public Text Name;
    public AudioClip clip;
    public Button button;

    public void SetData()
    {
        icon.sprite = data.icons[0];
        icon.color = data.color;
        Name.text = data.word;
    }
}
