using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogUnitContent : MonoBehaviour
{
    public static CatalogUnitContent instance;

    public List<UnitDetails> units;

    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    } 
}
