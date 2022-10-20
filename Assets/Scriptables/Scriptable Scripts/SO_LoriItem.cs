using UnityEngine;

public class SO_LoriItem : ScriptableObject
{
    [SerializeField] protected Enm_RewardType type = Enm_RewardType.None;

    public Sprite icon;
    public string code;
}
