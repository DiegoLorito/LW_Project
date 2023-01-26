using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class LoadingDotElastic : MonoBehaviour
{
    public List<Transform> dots;
    public float stretchAmount = 0.25f;

    private List<float> dotsYScale;
    private Sequence seqAnimation;

    private void Awake()
    {
        dotsYScale = new List<float>();

        for (int i = 0; i < dots.Count; i++)
        {
            dotsYScale.Add(dots[i].localScale.y);
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].localScale = Vector3.one;
        }

        seqAnimation = DOTween.Sequence();

        seqAnimation
            .Append(dots[0].DOScaleY(dotsYScale[0] + stretchAmount, 0.25f))
            .AppendCallback(()=> dots[0].DOScaleY(dotsYScale[0], 0.25f))

            .Append(dots[1].DOScaleY(dotsYScale[1] + stretchAmount, 0.25f))
            .AppendCallback(() => dots[1].DOScaleY(dotsYScale[1], 0.25f))

            .Append(dots[2].DOScaleY(dotsYScale[2] + stretchAmount, 0.25f))
            .Append(dots[2].DOScaleY(dotsYScale[2], 0.25f))
            .SetLoops(-1);
    }
    private void OnDisable()
    {
        seqAnimation.Kill();
    }

}
