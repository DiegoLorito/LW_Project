using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class LoadingDotPulse : MonoBehaviour
{
    public float duration = 0.35f;

    private List<Transform> dots;
    private Sequence seqAnimation;

    private void Awake()
    {
        dots = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            dots.Add(transform.GetChild(i));
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].localScale = Vector3.zero;
        }

        seqAnimation = DOTween.Sequence();

        seqAnimation
            .Append(dots[0].DOScale(1, duration).SetEase(Ease.Linear))
            .AppendCallback(() => dots[0].DOScale(0, duration).SetEase(Ease.Linear))

            .Append(dots[1].DOScale(1, duration).SetEase(Ease.Linear))
            .AppendCallback(() => dots[1].DOScale(0, duration).SetEase(Ease.Linear))

            .Append(dots[2].DOScale(1, duration).SetEase(Ease.Linear))
            .Append(dots[2].DOScale(0, duration).SetEase(Ease.Linear))
            .SetLoops(-1);
    }
    private void OnDisable()
    {
        seqAnimation.Kill();
    }
}
