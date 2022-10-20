using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP I spy", menuName = "Scriptable Objects/Template/TP I spy")]
public class SO_TemplateIspy : SO_Template
{
    [Header("Vocabulary")]
    public List<Sprite> vocab;
    public List<Sprite> vocabUI;
    public List<AudioClip> clipVocab;
    public List<string> oracionVocab;
    public List<Games_Set> catologo;

    [System.Serializable]
    public class Games_Set
    {
        public string nombre;
        public Sprite sprtBg;
        public List<Vector3> posObjets;
    }

}
