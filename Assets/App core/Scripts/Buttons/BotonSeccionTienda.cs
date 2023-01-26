using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BotonSeccionTienda : MonoBehaviour
{
    public int seccion;
    public Image background;
    public Text text;

    public bool clicked;
    private Button boton;

    private void Awake()
    {
        //GameEvents.onChangeShopSeccion += Clicked;

        //boton = GetComponent<Button>();
        //boton.onClick.AddListener(() => GameEvents.ChangeShopSeccion(seccion));
    }
    private void Clicked(int index)
    {
        if(index == seccion)
        {
            clicked = true;
            boton.interactable = false;
            background.DOColor(ConstantsUI.colorLightBlue, 0.25f);
            text.DOColor(ConstantsUI.colorWhite, 0.25f);
        }
        else
        {
            if (clicked)
            {
                clicked = false;
                boton.interactable = true;
                background.DOColor(ConstantsUI.colorWhite, 0.25f);
                text.DOColor(ConstantsUI.colorLightBlue, 0.25f);

            }
        }
    }

    private void OnDestroy()
    {
        //GameEvents.onChangeShopSeccion -= Clicked;
    }

}
