using UnityEngine;
//using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.CanvasScaler))]
public class CanvasScalerFitScreen : MonoBehaviour
{
    private UnityEngine.UI.CanvasScaler _canvasScaler;


    private void Awake()
    {
        _canvasScaler = GetComponent<UnityEngine.UI.CanvasScaler>();

        if (Helper.IsIpadScreen)
        {
            _canvasScaler.matchWidthOrHeight = 0;
        }
        else
        {
            _canvasScaler.matchWidthOrHeight = 1;
        }
    }
}
