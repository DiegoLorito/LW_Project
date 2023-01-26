using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBasic : MonoBehaviour
{
    public string stringValue;
    [HideInInspector] public int intValue;
    public bool completed;

    public virtual void ClearInput() { }
}
