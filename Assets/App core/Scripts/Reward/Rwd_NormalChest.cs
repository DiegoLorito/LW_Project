public class Rwd_NormalChest : SpotBase
{
    public SO_NormalChest data;

    private void Awake()
    {
        Layout = GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        button.onClick.AddListener(delegate { GameEvents.RewardNormalChest(); });
    }
}
