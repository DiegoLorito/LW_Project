using UnityEngine;

public class CardActivity : MonoBehaviour
{
    public CardActivityData data;

    public UnityEngine.UI.Image icon;
    public UnityEngine.UI.Image background;
    public UnityEngine.UI.Text title;
    public UnityEngine.UI.Text worldUnit;
     
    public void SetData()
    {
        icon.sprite = data.icon;
        title.text = data.title;
        worldUnit.text = data.world + " - " + "Unit " + data.number;
        background.color = data.bgColor;
    }
}
