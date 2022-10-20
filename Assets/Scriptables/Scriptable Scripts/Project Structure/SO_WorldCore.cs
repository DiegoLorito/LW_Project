using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Core", menuName = "Scriptable Objects/World Core")] 
public class SO_WorldCore : ScriptableObject
{
    public int id;
    public string Name;
    public string code;
    public int minAge;
    public int maxAge;
    public Sprite icon;
    public Color color;

    public List<SO_UnitCore> unitsCore;
    public List<UnitData> units;
}
