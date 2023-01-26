using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogoUnidades : MonoBehaviour
{
    public List<UnitLocalData> unidades;
}

[System.Serializable]
public class UnitLocalData
{
    public string name;
    public int id;
    public Sprite sprite;
    public Sprite spriteBackgroundIcon;
    public Color color;
    public Color colorBackgroundIcon;
}
