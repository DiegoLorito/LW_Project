
public class InputWorldOption : InputImageOption
{
    public SO_WorldCore data;  

    public UnityEngine.UI.Image background;
    public UnityEngine.UI.Image checkIcon;
    public UnityEngine.UI.Text ageRange;
    public UnityEngine.UI.Text worldName;

    private void Awake()
    {
        icon.sprite = data.icon;

        background.color = data.color;
        ageRange.color = data.color;
        checkIcon.color = data.color;
        icon.sprite = data.icon;

        worldName.text = data.Name;
        ageRange.text = data.minAge + " - " + data.maxAge + " years";


        check.SetActive(false);
    }
    public void SelectWorld()
    {
        controller.intValue = data.id;
        controller.completed = true;
        controller.SelectOption(transform.GetSiblingIndex());
    }

}
