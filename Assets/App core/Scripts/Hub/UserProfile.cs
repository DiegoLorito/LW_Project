using UnityEngine;
using UnityEngine.UI;

public class UserProfile : MonoBehaviour
{
    [SerializeField] private Image img_avatar;
    [SerializeField] private Image img_worldIndicator;

    [SerializeField] private Text txt_coins;
    [SerializeField] private Text txt_unitIndex;

    [SerializeField] private TMPro.TextMeshProUGUI txt_name;

    public void SetData(UserData dataUser)
    {
        img_avatar.sprite = LocalData.Instance.GetDataAvatar(dataUser.avatarCode).icon;
        img_avatar.sprite = LocalData.Instance.GetDataAvatar(dataUser.avatarCode).icon;
        img_worldIndicator.color = LocalData.Instance.GetDataWorld(dataUser.avatarCode).color;

        txt_unitIndex.text = dataUser.CurrentUnit.index.ToString();

        if (txt_coins) txt_coins.text = dataUser.coins.ToString();

        txt_name.text = dataUser.name;
    }

}
