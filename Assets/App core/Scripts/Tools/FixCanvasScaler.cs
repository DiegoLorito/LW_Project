using UnityEngine;

public class FixCanvasScaler : MonoBehaviour
{
    public UnityEngine.UI.CanvasScaler canvasScaler;

    void Start()
    {
        RectTransform rectCanvas = canvasScaler.GetComponent<RectTransform>();

        bool needScale = rectCanvas.rect.width > rectCanvas.rect.height / 2;

        if (needScale && Screen.orientation == ScreenOrientation.Portrait)
        {
            canvasScaler.matchWidthOrHeight = 1f;
        }
        else if (!needScale && Screen.orientation == ScreenOrientation.Portrait)
        {
            canvasScaler.matchWidthOrHeight = 0f;
        }
    }

}
