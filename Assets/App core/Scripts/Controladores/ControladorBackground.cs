using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ControladorBackground : MonoBehaviour
{
    public Image imgBackground;

    private void Awake()
    {
        GameEvents.onBackgroundSetColor += BackgroundChangeColor;
    }

    private void BackgroundSetSetActive(bool active)
    {
        float value = active ? 1 : 0;

        if (active) imgBackground.gameObject.SetActive(true);

        imgBackground.DOFade(value, 0.25f).OnComplete(delegate { imgBackground.gameObject.SetActive(active); });
       
    }
    private void BackgroundChangeColor(Color color)
    {
        imgBackground.DOColor(color, 0.25f);
    }

    private void OnDestroy()
    {
        GameEvents.onBackgroundSetColor -= BackgroundChangeColor;
    }
}
