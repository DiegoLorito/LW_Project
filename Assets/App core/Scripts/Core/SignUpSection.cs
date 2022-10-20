using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using System;

public class SignUpSection : MonoBehaviour
{
    public ScreenSignIn controller;

    public List<InputFieldBasic> inputs;
    public Button buttonNext;

    private void Awake()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            inputs[i].input.onValueChanged.AddListener(delegate { CheckAllCompleted(); });
        }

        buttonNext.interactable = false;
        buttonNext.image.color = ConstantsUI.colorGray;
    }
    private void CheckAllCompleted()
    {
        bool conditionCompleted = !inputs.Exists((x)=> x.completed == false);

        //for (int i = 0; i < inputs.Count; i++)
        //{
        //    print(inputs[i].name + ": " + inputs[i].completed);
        //}

        if (conditionCompleted)
        {
            buttonNext.interactable = true;
            buttonNext.image.DOColor(ConstantsUI.colorPurple, 0.25f);
        }
        else
        {
            buttonNext.interactable = false;
            buttonNext.image.DOColor(ConstantsUI.colorGray, 0.25f);
        }
    }
    public void Restart()
    {
        buttonNext.interactable = false;
        buttonNext.image.DOColor(ConstantsUI.colorGray, 0.25f);

        for (int i = 0; i < inputs.Count; i++)
        {
            inputs[i].input.text = "";
        }
    }

}
