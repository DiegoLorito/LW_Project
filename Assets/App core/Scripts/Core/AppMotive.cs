using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class AppMotive : MonoBehaviour
{
    public RectTransform canvas;

    public Image background;
    public RawImage pattern;

    [Header("Scroll Speed")]
    public float scrollSpeedX;
    public float scrollSpeedY;

    //public AppMotiveTheme theme;

    private void Awake()
    {
        GameEvents.onUpdateTransitionPatternResolution += UpdatePatternResolution;
        GameEvents.onBackgroundSetColor += SetMotiveColor;
    }

    private void SetMotiveColor(Color color)
    {
        background.color = color;

        float h, s, v = 0;
        Color.RGBToHSV(color,out h,out s,out v);

        s -= 0.05f;
        v += 0.05f;

        pattern.color = Color.HSVToRGB(h, s, v);

    }

    private void Update()
    {
        pattern.uvRect = new Rect((Time.time * scrollSpeedX) % 1, (Time.time * scrollSpeedY) % 1, pattern.uvRect.width, pattern.uvRect.height);
    }

    private void UpdatePatternResolution()
    {
        float width = canvas.rect.width;
        float height = canvas.rect.height;

        if (width < height)
        {
            float ratio = (height / width) * 3;
            pattern.uvRect = new Rect(pattern.uvRect.x, pattern.uvRect.y, 3, ratio);
        }
        else
        {
            float ratio = (width / height) * 3;
            pattern.uvRect = new Rect(pattern.uvRect.x, pattern.uvRect.y, ratio, 3);
        }
    }
    private void OnDestroy()
    {
        GameEvents.onUpdateTransitionPatternResolution -= UpdatePatternResolution;
        GameEvents.onBackgroundSetColor -= SetMotiveColor;
    }



}

[System.Serializable]
public class AppMotiveTheme
{
    public Color clBackground;
    public Color clPattern;
}
