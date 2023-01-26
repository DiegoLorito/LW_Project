using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadingDotSpin : MonoBehaviour
{
    public float duration = 0.35f;
    public float delay = 3;

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

        for (int i = 0; i < dots.Count; i++)
        {
            int index = i;

            seqAnimation.AppendCallback(() => DotScale(dots[index])); 
            seqAnimation.AppendInterval(duration);
        }

        seqAnimation.SetLoops(-1);

        void DotScale(Transform dot)
        {
            dot.DOScale(1, duration).SetEase(Ease.Linear);
            dot.DOScale(0, duration).SetDelay(delay).SetEase(Ease.Linear).OnComplete(() => dot.transform.DOKill()) ;
        }

    }

    private void OnDisable()
    {
        seqAnimation.Kill();

        for (int i = 0; i < dots.Count; i++)
        {
            int index = i;

            dots[index].localScale = Vector3.zero;
            dots[index].transform.DOKill();
        }
    }
}
