using UnityEngine;

[CreateAssetMenu(fileName = "new reward", menuName = "Scriptable Objects/Data Reward")] 
public class RewardData : ScriptableObject
{
    public string code;
    public string Name;
    public string Category;
    public Sprite icon;
    public System.DateTime date; 
}
