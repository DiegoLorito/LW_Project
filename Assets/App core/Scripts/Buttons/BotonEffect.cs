using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BotonEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float currScale;

    private void Awake()
    {
        currScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(0.95f * currScale, 0.2f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(currScale, 0.2f);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
