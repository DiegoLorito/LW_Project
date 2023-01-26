using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSeccionLoriland : MonoBehaviour
{
    public int id;
    public GameObject seccion;

    private void Awake()
    {
        //GameEvents.onChangeHUBSection += CambiarSeccion;
    }
    public void ElegirSeccion()
    {
        //GameEvents.ChangeHUBSection(id);
    }
    private void CambiarSeccion(int _id)
    {
        if(_id != id)
        {
            seccion.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            seccion.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        //GameEvents.onChangeHUBSection -= CambiarSeccion;
    }
}
