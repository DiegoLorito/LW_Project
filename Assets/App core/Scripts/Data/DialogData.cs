using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog Data", menuName = "Scriptable Objects/DialogData")]
public class DialogData: ScriptableObject
{
    public enum TypeDialog { Normal, Error, Warning}

    [Space(10)]
    public string title;
    public string description;

    [Space(10)]
    [Header("Dialog Settings")]
    public Sprite image;
    public Color iconColor = Color.white;
    public bool hasButtonClose;

    public ButtonSettings settButton1;
    public ButtonSettings settButton2;

    public Action actionOne;
    public Action actionTwo;

    [Space(10)]
    public TypeDialog type;
    //public Color color;
}

[System.Serializable]
public class ButtonSettings
{
    public bool hasIcon;
    public string text;
}
