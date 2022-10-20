using UnityEngine;

[CreateAssetMenu(fileName = "Unit Core", menuName = "Scriptable Objects/App Sctructure/Unit Core")]
public class SO_UnitCore : ScriptableObject
{
    [Header("Identifiers")]
    public string code;
    
      
    [Space(10)]
    [Header("Information")] 
    public string Name;
    public int index;
    public System.DateTime date;
    [TextArea(5,5)]
    public string description;

    [Space(10)]
    [Header("Sprites")]
    public Sprite icon;
    public Sprite background;
    public Sprite thumbnail;

    public Color colorBackground;
    public Color colorMiddleground;
}
