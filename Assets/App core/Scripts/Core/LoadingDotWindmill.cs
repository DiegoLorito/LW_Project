using UnityEngine;
using DG.Tweening;

public class LoadingDotWindmill : MonoBehaviour
{
    public float duration = 0.35f;

    private Tween twAnimation;

    private void OnEnable()
    {
        twAnimation = transform.DORotate(new Vector3(1,1,1), duration, RotateMode.LocalAxisAdd).SetLoops(-1);
    }
    private void OnDisable()
    {
        twAnimation.Kill();
    }
}
