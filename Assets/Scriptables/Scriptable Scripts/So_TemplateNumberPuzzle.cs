using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP NumberPuzzle", menuName = "Scriptable Objects/Template/TP NumberPuzzle")]
public class So_TemplateNumberPuzzle : SO_Template
{
    public List<Round> rounds;
    public Vector3 posBirdHint;
    public Vector3 finBirdHint;
    [System.Serializable]
    public class Round
    {
        public string vocab;
        public GameObject slide;
        public AudioClip clipVocab;
        public int correctRound;
        public List<Vector3> posPuzzle;
    }
    
}
