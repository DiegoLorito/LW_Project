using UnityEngine;
using UnityEngine.UI;


public class TestAvatarCard : MonoBehaviour
{
    public Image imgIcon;
    public Text txtCode;

    public void SetData(SO_Avatar data)
    {
        imgIcon.sprite = data.icon;
        txtCode.text = data.code;
    }
}
