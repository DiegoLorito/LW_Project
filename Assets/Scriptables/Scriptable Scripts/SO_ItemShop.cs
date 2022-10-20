//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Shop", menuName = "Scriptable Objects/Shop/Item")]
public class SO_ItemShop : SO_LoriItem
{
    public string nombre;
    public int precio;
    public string typeCode;
    public Sprite miniatura;
    public GameObject prefab;
}
