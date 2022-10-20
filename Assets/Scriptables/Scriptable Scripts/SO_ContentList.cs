using UnityEngine;

[CreateAssetMenu(fileName = "Content List", menuName = "Scriptable Objects/Content/Content List")]
public class SO_ContentList : ScriptableObject
{
    public SO_ContentBase[] contentBases;
}
