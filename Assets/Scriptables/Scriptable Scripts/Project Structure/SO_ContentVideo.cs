using UnityEngine;

[CreateAssetMenu(fileName = "Content Video", menuName = "Scriptable Objects/Content/Content Video")]
public class SO_ContentVideo : SO_Content
{
    [Space(10)]
    public string videoUrl;

    [Space(10)]
    [Header("Rewards Data")]
    public SO_LoriItem[] rewards;

    private void Awake()
    {
        templateCode = "TP_01";
    }

    //public override Sprite Icon => videoIcon;
}
