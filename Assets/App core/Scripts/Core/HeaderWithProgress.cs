

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeaderWithProgress : MonoBehaviour
{
    [Header("Navigation")]
    public LayoutElement[] indicators;

    public void SetIndicatorFocus(int index)
    {
        if (index > indicators.Length || index < 0) return;

        for (int i = 0; i < indicators.Length; i++)
        {
            if (i == index)
            {
                indicators[i].GetComponent<Image>().DOColor(ConstantsUI.colorPurple, 0.5f);
                indicators[i].DOFlexibleSize(new Vector2(2, 0), 0.5f);
            }
            else
            {
                indicators[i].GetComponent<Image>().DOColor(ConstantsUI.colorLightPurple2, 0.5f);
                indicators[i].DOFlexibleSize(new Vector2(1, 0), 0.5f);
            }
        }
    }
}
