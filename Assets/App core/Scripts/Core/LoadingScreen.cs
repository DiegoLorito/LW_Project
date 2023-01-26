using UnityEngine;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    private bool loading;

    public CanvasGroup group;
    public Transform indicador;

    private Sequence seqIndicador;

    private void Awake()
    {
        //GameEvents.onShowLoadingScreen += ShowLoadingScreen;
        //GameEvents.onHideLoadingScreen += LoadingFinished;
    }
    private void ShowLoadingScreen()
    {
        if (loading) return;

        loading = true;

        group.gameObject.SetActive(true);

        group.alpha = 0;
        indicador.localScale = Vector3.zero;

        Sequence seq = DOTween.Sequence();

        seq.Append(group.DOFade(1, 0.25f))
            .OnComplete(delegate
            {
                LoopIndicador();
            });

    }
    private void LoopIndicador()
    {
        float maxSize = Random.Range(1.5f,1.75f);
        float minSize = Random.Range(0.5f, 1.0f);

        seqIndicador = DOTween.Sequence();

        seqIndicador.Append(indicador.DOScale(maxSize, 0.5f))
            .Append(indicador.DOScale(minSize, 0.5f))
            .OnComplete(delegate
            {
                LoopIndicador();
            });
    }
    private void LoadingFinished()
    {
        loading = false;

        group.DOFade(0, 0.25f).OnComplete(delegate
        {
            seqIndicador.Kill();
            group.gameObject.SetActive(false);
        });
    }

    private void OnDestroy()
    {
        seqIndicador.Kill();
        group.DOKill();

        //GameEvents.onShowLoadingScreen -= ShowLoadingScreen;
        //GameEvents.onHideLoadingScreen -= LoadingFinished;
    }
}
