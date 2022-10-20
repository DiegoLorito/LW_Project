using UnityEngine;

public class Rwd_SpecialChest : SpotBase
{
    [HideInInspector] public SO_SpecialChest data;

    private SO_LoriItem[] _rewards;

    private void Awake()
    {
        Layout = GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        button.onClick.AddListener(delegate { GameEvents.RewardSpecialChest(data.rewards); });
    }

    public override void SetData()
    {
        _rewards = data.rewards;
    }
}
