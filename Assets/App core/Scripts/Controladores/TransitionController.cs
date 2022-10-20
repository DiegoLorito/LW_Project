using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;
//using UnityEngine.UI

public class TransitionController : MonoBehaviour
{
    public static TransitionController instance;

    private RectTransform canvas;
    public RectTransform mask;
    private Sequence seqTransition;

    private bool playingAnimation;
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        GameEvents.onScreenTransition += ScreenTransition;
        GameEvents.onHideLoadingScreen += TransitionOut;

        canvas = GetComponent<RectTransform>();
    }
    private void ScreenTransition(Action action = null)
    {
        if (playingAnimation) return;

        float screenWidth = canvas.rect.width;

        playingAnimation = true;
        mask.parent.gameObject.SetActive(true);

        GameEvents.CanvasInteractable(false);
        GameEvents.UpdateTransitionPatternResolution();

        PositionScreen();

        seqTransition = DOTween.Sequence();

        seqTransition.Append(mask.DOSizeDelta(new Vector2(screenWidth * 1.2f, 0), 0.25f).SetEase(Ease.Linear))
            .AppendCallback(delegate { action?.Invoke(); })
            .AppendInterval(0.25f)
            .Append(mask.DOAnchorPosX(screenWidth, 0.25f).SetEase(Ease.Linear))
            .OnComplete(()=>
            {
                mask.parent.gameObject.SetActive(false);
                playingAnimation = false;

                GameEvents.CanvasInteractable(true);
            });
    }
    public IEnumerator RoutineTransitionIn()
    {
        float duration = 0.5f;

        GameEvents.UpdateTransitionPatternResolution();

        if (playingAnimation) yield break;

        duration = Screen.orientation == ScreenOrientation.Portrait ? duration/2 : duration;
        float screenWidth = canvas.rect.width;

        mask.parent.gameObject.SetActive(true);
        playingAnimation = true;

        PositionScreen();

#if UNITY_EDITOR
        duration = 0.5f;
#endif

        mask.DOSizeDelta(new Vector2(screenWidth * 1.2f, 0), duration).SetEase(Ease.Linear);

        yield return new WaitForSeconds(duration);
        yield break;
    }
    private void TransitionOut()
    {
        seqTransition = DOTween.Sequence();

        float duration = Screen.orientation == ScreenOrientation.Portrait ? 0.25f : 0.5f;
        float screenWidth = canvas.rect.width;

#if UNITY_EDITOR
        duration = 0.5f;
#endif

        seqTransition
            .Append(mask.DOAnchorPosX(screenWidth, duration).SetEase(Ease.Linear))
            .OnComplete(() =>
            {
                mask.parent.gameObject.SetActive(false);
                playingAnimation = false;
                GameEvents.CanvasInteractable(true);
            });
    }

    private void PositionScreen()
    {
        float screenWidth = canvas.rect.width;

        mask.sizeDelta = new Vector2(screenWidth * 0.1f, 0);
        mask.anchoredPosition = new Vector2(-screenWidth * 0.1f, 0);
    }


    private void OnDestroy()
    {
        seqTransition.Kill();

        GameEvents.onScreenTransition -= ScreenTransition;
        GameEvents.onHideLoadingScreen -= TransitionOut;
    }
}
