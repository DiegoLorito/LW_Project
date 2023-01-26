using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class AppInitialController : AppScreenController
{
    public override void Awake()
    {
        GameEvents.onTransitionScene += TransitionScene;

        Screen.orientation = ScreenOrientation.Portrait;

        fadeScene.gameObject.SetActive(true);
        fadeScene.DOFade(1, 0.0f);

        base.Awake();
    }

    private void Start()
    {

        if (ControladorData.instance.isLogged())
        {
            AppJsonData data = ControladorData.instance.data;

            AppServerData.instance.dataClient = data.client;
            AppServerData.instance.dataCurrentUser = data.user;

            bool screenUsers = data.loggedIn && !data.userSelected;
            bool screenGames = data.loggedIn && data.userSelected;

            if (screenUsers)
            {
                screens[1].EnableScreen(true);
                screens[1].LoadContent();

                (screens[1] as ScreenLogIn).textClientEmail.text = data.client.email;
                (screens[1] as ScreenLogIn).textClientPassword.text = data.client.password;

                (screens[1] as ScreenLogIn).LogIn();
                fadeScene.DOFade(0, 0.5f);
            }

            if (screenGames)
            {
                TransitionScene("App Hub");
                return;
            }
        }
        else
        {
            screens[0].EnableScreen(true);
            screens[0].LoadContent();
            fadeScene.DOFade(0, 0.5f);
        }


        GameEvents.UpdateTransitionPatternResolution();
    }

    private void OnDestroy()
    {
        GameEvents.onTransitionScene -= TransitionScene;
    }


}
