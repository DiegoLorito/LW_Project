using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP PeanutsMacaws", menuName = "Scriptable Objects/Template/TP PeanutsMacaws")]
public class SO_TemplatePeanutsMacaws : SO_Template
{
    [Header("Vocabulario")]
    public List<string> word;
    public List<AudioClip> clip;
    public List<string> wordComplete;

    [Header("Slides")]
    public List<Slide> slides;

    [System.Serializable]
    public class Slide
    {
        public string slideName;
        public enum tipo { show, drag, matching, ninja, final }
        public tipo clase = tipo.show;
        public int itemCount;
        public int pjCount;
        public GameObject slide;
    }
}
