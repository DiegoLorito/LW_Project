using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ControladorTransiciones : MonoBehaviour
{
    public Image imgFade;
   
    private void Awake()
    {
        GameEvents.onFadeTransition += Fade;
    }
    private void Fade(Action myAction)
    {
        imgFade.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(imgFade.DOFade(1, 0.5f))
            .AppendInterval(0.25f)
            .AppendCallback(delegate
            {
                if (myAction != null) myAction();
            })
            .Append(imgFade.DOFade(0, 0.5f))
            .OnComplete(() => imgFade.gameObject.SetActive(false));
    }
    private void OnDestroy()
    {
        GameEvents.onFadeTransition -= Fade;
    }

}
