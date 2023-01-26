using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadingDotFlashing : MonoBehaviour
{
    public float duration = 0.35f;

    private List<UnityEngine.UI.Image> dots;
    private Sequence seqAnimation;

    private void Awake()
    {
        dots = new List<UnityEngine.UI.Image>();

        for (int i = 0; i < transform.childCount; i++)
        {
            dots.Add(transform.GetChild(i).GetComponent<UnityEngine.UI.Image>());
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].DOFade(0.3f,0);
        }

        seqAnimation = DOTween.Sequence();

        seqAnimation
            .Append(dots[0].DOFade(1, duration).SetEase(Ease.Linear))
            .AppendCallback(() => dots[0].DOFade(0.3f, duration).SetEase(Ease.Linear))

            .Append(dots[1].DOFade(1, duration).SetEase(Ease.Linear))
            .AppendCallback(() => dots[1].DOFade(0.3f, duration).SetEase(Ease.Linear))

            .Append(dots[2].DOFade(1, duration).SetEase(Ease.Linear))
            .Append(dots[2].DOFade(0.3f, duration).SetEase(Ease.Linear))
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        seqAnimation.Kill();
    }
}
