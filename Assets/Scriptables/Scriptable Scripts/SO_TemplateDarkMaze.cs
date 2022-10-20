using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Dark Maze", menuName = "Scriptable Objects/Template/TP Dark Maze")]
public class SO_TemplateDarkMaze : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Vocabulary")]
    public List<Biblioteca> bibliotecas;

    [System.Serializable]
    public class Biblioteca
    {
        public string word;
        public string inCorrect;
        public Sprite icon;
        public AudioClip clip;
        public AudioClip clipCorrecto;
        public int val;
        public string phrase;

    }
}
