using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TP Coloring", menuName = "Scriptable Objects/Template/TP Coloring")]
public class So_TemplateColoring : SO_Template
{
    [Header("Vocabulario")]
    public List<Sprite> vocab;
    public List<AudioClip> clipVocab;
    public List<Color> colorVocab;
    public GameObject prfb_Colorear;
    public Sprite muestraPart;
    public Vector3 posMuestraPart;
}
