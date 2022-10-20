using System;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [HideInInspector] public DialogData data;

    public Text title;
    public Text descripton;

    public Image image;

    public DialogButton button1;
    public DialogButton button2;

    public Button buttonClose;

    private void Awake()
    {
        buttonClose.onClick.AddListener(() => GameEvents.HideDialog());
    }

    public void SetData()
    {
        title.text = data.title;
        descripton.text = data.description;

        switch (data.type)
        {
            case DialogData.TypeDialog.Normal:
                title.color = ConstantsUI.colorPurple;
                button1.button.image.color = ConstantsUI.colorEmerald;
                break;
            case DialogData.TypeDialog.Error:
                title.color = ConstantsUI.colorPink1;
                button1.button.image.color = ConstantsUI.colorPink1;
                break;
            case DialogData.TypeDialog.Warning:
                title.color = ConstantsUI.colorYellow2;
                button1.button.image.color = ConstantsUI.colorYellow2;
                break;
            default:
                break;
        }

        if (data.image != null)
        {
            image.gameObject.SetActive(true);
            image.sprite = data.image;
            image.color = data.iconColor;
        }
        else
        {
            image.gameObject.SetActive(false);
        }

        if (data.hasButtonClose) buttonClose.gameObject.SetActive(true);
        else buttonClose.gameObject.SetActive(false);

        SetButton(data.settButton1, button1, data.actionOne);
        SetButton(data.settButton2, button2, data.actionTwo);
    }

    private void SetButton(ButtonSettings settings, DialogButton _dialogButton, Action action = null)
    {
        if (settings.text != "")
        {
            _dialogButton.button.gameObject.SetActive(true);

            _dialogButton.button.onClick.RemoveAllListeners();
            _dialogButton.button.onClick.AddListener(() => action());
            _dialogButton.buttonText.text = settings.text;

            if (settings.hasIcon)
            {
                _dialogButton.icon.gameObject.SetActive(true);
            }
            else
            {
                _dialogButton.icon.gameObject.SetActive(false);
            }
        }
        else
        { 
            _dialogButton.button.gameObject.SetActive(false);
        }
    }


}

