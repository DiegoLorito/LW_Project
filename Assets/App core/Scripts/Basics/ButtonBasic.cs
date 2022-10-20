using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonBasic : MonoBehaviour
{
    public Button button;
    public Text text;
    public Image leadIcon;
    public Image trailIcon;

    [Header("Colors")]
    public ButtonTheme activeTheme;
    public ButtonTheme inactiveTheme;

    public void SetButtonActive(bool active, float duration = 0)
    {
        if (active)
        {
            button.interactable = true;

            if (text) text.DOColor(activeTheme.colorSecondary, duration);
            if (leadIcon) leadIcon.DOColor(activeTheme.colorSecondary, duration);
            if (trailIcon) trailIcon.DOColor(activeTheme.colorSecondary, duration);


            button.image.DOColor(activeTheme.colorPrimary, duration);
        }
        else
        {
            button.interactable = false;

            if (text) text.DOColor(inactiveTheme.colorSecondary, duration);
            if (leadIcon) leadIcon.DOColor(inactiveTheme.colorSecondary, duration);
            if (trailIcon) trailIcon.DOColor(inactiveTheme.colorSecondary, duration);


            button.image.DOColor(inactiveTheme.colorPrimary, duration);
        }

        button.interactable = active;
    }
}

[System.Serializable]
public class ButtonTheme
{
    public Color colorPrimary;
    public Color colorSecondary;
}