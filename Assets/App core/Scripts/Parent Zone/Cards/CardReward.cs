using UnityEngine;

public class CardReward : MonoBehaviour
{
    [HideInInspector]public CardRewardData data;

    public UnityEngine.UI.Image icon;
    public UnityEngine.UI.Text Name;

    public void SetData()
    {
        icon.sprite = data.icon;
        Name.text = data.Name;
    }
}
