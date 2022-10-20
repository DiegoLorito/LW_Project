using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ControladorAppInterfase : MonoBehaviour
{
    //private CAnvas
    public RectTransform rectCanvas;    
    public string escenaArbol;
    private bool quicking;

    [Space(10)]
    [Header("Pantallas")]
    public GameObject[] listaPantallas;
    // [0] Home
    // [1] Log In
    // [2] Sign in
    // [3] User register
    // [4] Users
    // [5] Units
    // [6] Games


    private int pantallaActual;
    private int pantallaAnterior;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        GameEvents.onBackScreen += VolverPantalla;
        GameEvents.onChangeAppScreen += CambiarPantalla;
        GameEvents.onCanvasInteractable += CanvasInteractable;

        // Apagamos todas las pantallas
        for (int i = 0; i < listaPantallas.Length; i++)
        {
            listaPantallas[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        // Si ya está Loggeado entra a la condicional
        if (ControladorData.instance.isLogged())
        {
            AppServerData.instance.dataClient = ControladorData.instance.data.client;
            AppServerData.instance.dataCurrentUser = ControladorData.instance.data.user;

            // Si esta loggeado pero no ha seleccionado un hijo
            if (!ControladorData.instance.data.userSelected)
            {
                GameEvents.FindUsers(AppServerData.instance.dataClient.id);
            }
            // Si esta loggeado y ha seleccionado un hijo
            else
            {
                int worldId = ControladorData.instance.data.user.worldId;
                //GameEvents.BackgroundSetColor(CatalogWorlds.instance.GetWorldDataById(worldId).color);
                //GameEvents.SetAvatarSprite(CatalogoAvatars.GetAvatar(ControladorData.instance.GetUserAvatarId(ControladorData.instance.GetUserAccountId())));

                // Si viene de una interacción
                if (LocalSavedData.GetComeFromInteraction())
                {
                    LocalSavedData.SetComeFromInteraction(false);

                    // Si la interacción ha sido completada
                    if (LocalSavedData.GetGameComplete())
                    {
                        LocalSavedData.SetGameComplete(false);
                        GameEvents.CreateProgress(LocalSavedData.GetContentId(), "00:00:00");
                    }
                    // Si la interacción NO ha sido completada
                    else
                    {
                        UserData _user = AppServerData.instance.dataCurrentUser;
                        //GameEvents.FindContent(CatalogWorlds.instance.GetUnit(_user.worldId, _user.codeCurrentUnit));
                    }
                }
                // Si NO viene de una interacción
                else
                {
                    UserData dataUser = ControladorData.instance.data.user;

                    //GameEvents.FindContent(CatalogWorlds.instance.GetUnit(dataUser.worldId, dataUser.codeCurrentUnit));
                }
            }
        }
        else
        {
            EstablecerPantalla(0, 0);
            GameEvents.HideLoadingScreen();
        }
    }

    public void GoLoriland()
    {
        SceneManager.LoadScene("LoriLand");        
    }
    public void CambiarPantalla(int id)
    {
        if(id == pantallaActual)
        {
            EstablecerPantalla(id, id);
            return;
        }

        switch (pantallaActual)
        {
            case 0:
                print("Vas por buen camino");
                break;
            //case 1:

            //    //GameEvents.HideLoadingScreen();
            //    break;
            case 4:

                if(id == 2)
                {
                    EstablecerPantalla(2, 1);
                    GameEvents.HideLoadingScreen();
                    return;
                }

                break;
            case 5:

                if (id == 2)
                {
                    //OcultarPopUp();
                }

                break;
            case 7:

                if (id == 2)
                {
                    EstablecerPantalla(1,2);
                    GameEvents.HideLoadingScreen();
                    return;
                }

                break;

            case 9:
                if (id == 2)
                {
                    EstablecerPantalla(2,1);
                    GameEvents.HideLoadingScreen();
                    return;
                }
                break;
            default:
                break;

        }

        pantallaAnterior = pantallaActual;
        pantallaActual = id;

        GameEvents.ScreenTransition(() => EstablecerPantalla(pantallaActual, pantallaAnterior));

    }
    public void EstablecerPantalla(int actual, int anterior)
    {
        if (anterior < 0) anterior = 0;
        if (actual < 0) actual = 0;

        listaPantallas[pantallaActual].SetActive(false);

        pantallaAnterior = anterior;
        pantallaActual = actual;

        listaPantallas[pantallaActual].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        listaPantallas[pantallaAnterior].SetActive(false);
        listaPantallas[pantallaActual].SetActive(true);
    }
    public void VolverPantalla()
    {
        if (pantallaActual == 0 && pantallaAnterior == 1) return;

        switch (pantallaActual)
        {
            case 2: //Retroceder a pantalla de HOME desde SIGN UP
                GameEvents.ShowNormalDialog(1);
                break;
            case 3: //Retroceder a pantalla de USERS desde USER REGISTER
                GameEvents.ShowNormalDialog(0);
                break;
            case 4: //Retroceder a pantalla de HOME desde USERS
                GameEvents.ShowNormalDialog(2);
                break;
            case 5: //Retroceder a pantalla de USUARIOS desde UNIDADES
                CheckData(
                    ControladorData.instance.usersLoaded,
                    delegate { GameEvents.ScreenTransition(() => EstablecerPantalla(4, 3)); },
                    delegate { GameEvents.FindUsers(ControladorData.instance.data.client.id);});
                break;
            case 6: //Retroceder a pantalla de UNIDADES desde CONTENIDO
                ControladorData.instance.data.userSelected = false;
                ControladorData.instance.SaveAppData();
                CheckData(
                    ControladorData.instance.unitsLoaded,
                    delegate { GameEvents.ScreenTransition(() => EstablecerPantalla(5, 4)); },
                    delegate { GameEvents.ScreenTransition(() => EstablecerPantalla(5, 4)); });
                    //delegate { GameEvents.FindUnits(AppServerData.instance.GetCurrentWorld()); });
                break;

            default:
                GameEvents.ScreenTransition(()=> EstablecerPantalla(pantallaActual - 1, pantallaActual - 2));
                break;
        }

    }
    private void CheckData(bool check, Action ifTrue, Action ifFalse)
    {
        ((check) ? ifTrue : ifFalse)();
    }
    private void CanvasInteractable(bool value)
    {
        rectCanvas.GetComponent<CanvasGroup>().interactable = value;
    }

    private void OnApplicationQuit()
    {
        ControladorData.instance.unitsLoaded = false;
        ControladorData.instance.usersLoaded = false;
        ControladorData.instance.SaveAppData();
    }

    private void OnDestroy()
    {
        GameEvents.onBackScreen -= VolverPantalla;
        GameEvents.onChangeAppScreen -= CambiarPantalla;
        GameEvents.onCanvasInteractable -= CanvasInteractable;
    }
}

