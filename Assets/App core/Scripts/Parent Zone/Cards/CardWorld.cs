using UnityEngine;

public class CardWorld : MonoBehaviour
{
    public WorldData data;

    public UnityEngine.UI.Image background;
    public UnityEngine.UI.Text worldName;
    public UnityEngine.UI.Text ageRange;
    public UnityEngine.UI.Image icon;

    [Header("Check")]
    public UnityEngine.UI.Image checkIcon;
    public GameObject check;

    public void SetData()
    {
        background.color = data.color;
        ageRange.color = data.color;
        checkIcon.color = data.color;
        icon.sprite = data.icon;
        
        worldName.text = data.Name;
        ageRange.text = data.minAge + " - " + data.maxAge + " years";
        ageRange.color = data.color;
    }
    public void EnableCheck(int idContidion)
    {
        check.SetActive(data.id == idContidion);
    }
}
