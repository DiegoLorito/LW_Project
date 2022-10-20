using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppHubController : AppScreenController
{
    public override void Awake()
    {
        GameEvents.onChangeAppScreen += ChangeAppScreen;
        GameEvents.onTransitionScene += TransitionScene;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        fadeScene.gameObject.SetActive(true);
        fadeScene.DOFade(1, 0.0f);

        base.Awake();
    }

    private void Start()
    {
        Debug.Log("Actualizar cambio de color");
        GameEvents.BackgroundSetColor(LocalData.Instance.GetDataWorld("UP").color);

        int currentScreen = 0;

        bool screenGames = ControladorData.instance.data.loggedIn && ControladorData.instance.data.userSelected;

        if (screenGames)
        {
            currentScreen = 1;
        }

        screens[currentScreen].EnableScreen(true);
        screens[currentScreen].LoadContent();
    }
    public void SetUserSelected(bool value)
    {
        ControladorData.instance.data.userSelected = value;
        ControladorData.instance.SaveAppData();
    }
    public override void ChangeAppScreen(int index)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].EnableScreen(i == index);
        }

        screens[index].LoadContent();
    }
    public override void TransitionAppScreen(int index)
    {
        List<IEnumerator> routines = new List<IEnumerator>()
        {
            TransitionController.instance.RoutineTransitionIn(),
            RoutinesController.Action(() => ChangeAppScreen(index)),
            RoutinesController.Action(() => GameEvents.HideLoadingScreen()),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }

    private void OnDestroy()
    {
        GameEvents.onChangeAppScreen -= ChangeAppScreen;
        GameEvents.onTransitionScene -= TransitionScene;
    }
}
