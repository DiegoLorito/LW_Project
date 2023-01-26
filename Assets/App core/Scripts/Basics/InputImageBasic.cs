using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputImageBasic : InputBasic
{
    public InputImageOption[] options;

    private void Awake()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].controller = this;
        }
    }
    public void SelectOption(int index)
    {
        completed = true;

        for (int i = 0; i < options.Length; i++)
        {
            options[i].check.SetActive(i == index);
        }
    }

    public override void ClearInput()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].check.SetActive(false);
        } 

        completed = false;
    }
}
