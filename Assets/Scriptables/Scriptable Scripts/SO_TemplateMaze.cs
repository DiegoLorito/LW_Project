using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TP Maze", menuName = "Scriptable Objects/Template/TP_Maze")]
public class SO_TemplateMaze : SO_Template
{
    [Header("Reinforcement")]
    public bool hasText;
    public bool hasCharacter;

    [Header("Audio Hint")]
    public AudioClip clipTutorial;

    [Space(10)]
    [Header("General Data")]
    public GameObject prfbPlayer;
    public GameObject prfbEnemy;

    [Space(10)]
    [Header("Tino Data")]
    public Sprite spTinoHead;
    public Sprite spTinoBody;

    [Space(10)]
    [Header("Tile Data")]
    public TileBase tileWall;
    public TileBase tilePath;

    [Header("Vocabulary")]
    public SO_VocabMaze[] vocabulary;
}
