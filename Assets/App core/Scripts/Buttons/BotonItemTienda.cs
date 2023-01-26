using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonItemTienda : MonoBehaviour
{
    //public item_shop item;

    public Image imagen;
    public Text texto;
    public Transform estrellas;

    public bool establecido;
    public Button boton;


    public void EstablecerEventos()
    {
        if (establecido) return;

        establecido = true;
        //boton.onClick.AddListener(delegate
        //{
        //    GameEvents.ShowPopUpItemShop(item);
        //});
    }
    public void EstablecerEstrellas(int index)
    {
        if(index < 2)
        {
            estrellas.GetComponent<RectTransform>().SetLeft(64);
            estrellas.GetComponent<RectTransform>().SetRight(64);
            estrellas.GetComponent<HorizontalLayoutGroup>().spacing = 0;
        }

        for (int i = 0; i < index + 1; i++)
        {
            estrellas.GetChild(i).gameObject.SetActive(true);
        }

        //Invoke("DisableHorizontalLayoutGroup", 0.25f);

    }
    private void DisableHorizontalLayoutGroup()
    {
        estrellas.GetComponent<HorizontalLayoutGroup>().enabled = false;
    }



}
