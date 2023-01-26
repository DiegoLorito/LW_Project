using UnityEngine;

public class InputAvatarOption : InputImageOption
{
    public SO_Avatar data;

    private void Awake()
    {
        icon.sprite = data.icon;
        check.SetActive(false);
    }
    public void SelectAvatar(UnityEngine.UI.Image indicator)
    {
        indicator.sprite = icon.sprite;

        controller.stringValue = data.code;
        controller.completed = true;
        controller.SelectOption(transform.GetSiblingIndex());
    }

}
