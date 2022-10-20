using UnityEngine;

[CreateAssetMenu(fileName = "Content Game", menuName = "Scriptable Objects/Content/Content Game")]
public class SO_ContentGame : SO_Content
{
    [Space(10)]
    [Header("Rewards Data")]
    public SO_LoriItem[] rewards;
}
