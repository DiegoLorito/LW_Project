using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO-Assets-", menuName = "Scriptable Objects/SO-Assets")]
public class SO_Assets : ScriptableObject
{
    public List<GameObject> lstObjs;
    public List<Sprite> lstSprts;
    public AudioClip acMusic;

}

