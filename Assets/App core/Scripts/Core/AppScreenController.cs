using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppScreenController : MonoBehaviour
{
    public UnityEngine.UI.Image fadeScene;

    [Space(10)]
    public AppScreen[] screens;
    public virtual void Awake()
    {
        GameEvents.onChangeAppScreen += ChangeAppScreen;
        GameEvents.onTransitionAppScreen += TransitionAppScreen;

        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].controller = this;
            screens[i].screen.SetActive(false);
        }
    }
    public virtual void ChangeAppScreen(int index)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].EnableScreen(i == index);
        }

        screens[index].LoadContent();
    }
    public virtual void TransitionAppScreen(int index)
    {
        GameEvents.CanvasInteractable(false);

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            TransitionController.instance.RoutineTransitionIn(),
            RoutinesController.Action(() => ChangeAppScreen(index)),
            RoutinesController.Action(() => GameEvents.HideLoadingScreen()),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    public virtual void TransitionScene(string scene) 
    {
        GameEvents.CanvasInteractable(false);

        PlayerPrefs.SetString("pscene", scene);

        fadeScene.gameObject.SetActive(true);
        fadeScene.DOFade(1, 0.5f).OnComplete(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        });
    }

    private void OnDisable()
    {
        GameEvents.onChangeAppScreen -= ChangeAppScreen;
        GameEvents.onTransitionAppScreen -= TransitionAppScreen;
    }
}
