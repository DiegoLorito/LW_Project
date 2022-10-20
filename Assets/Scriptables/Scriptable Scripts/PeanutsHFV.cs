using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new peanutsHFV", menuName = "Scriptable Objects/Data PeanutsHFV")]
public class PeanutsHFV : ScriptableObject
{
    public string wordName;
    public enum tipo { show, drag, matching ,ninja , final}
    public tipo clase = tipo.show;
    public int itemCount;
    public int pjCount;
    public GameObject slide;
}
