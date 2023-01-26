using UnityEngine;
using UnityEngine.UI;

public class ColorToHex : MonoBehaviour
{
    public Color color;
    public Text text;

    void Start()
    {
        string hexValue = ColorUtility.ToHtmlStringRGBA(color);

        string firstChar = text.text[0].ToString();
        string leftChars = text.text.Substring(1);

        string colorChar = $"<color=#{hexValue}>{firstChar}</color>";

        text.text = colorChar + leftChars;
    }


}
