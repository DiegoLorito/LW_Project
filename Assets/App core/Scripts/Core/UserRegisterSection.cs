using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UserRegisterSection : MonoBehaviour
{
    [HideInInspector]public UserRegister controller;

    public string header;
    public List<InputBasic> inputs;

    [Header("Button")]
    public bool initialCondition;
    public ButtonBasic buttonNext;

    private void Awake()
    {
        buttonNext.SetButtonActive(initialCondition);
    }
    public void CheckAllCompleted()
    {
        bool conditionCompleted = !inputs.Exists((x) => x.completed == false);
        buttonNext.SetButtonActive(conditionCompleted, 0.25f);
    }
    public void Restart()
    {
        buttonNext.SetButtonActive(initialCondition);

        for (int i = 0; i < inputs.Count; i++)
        {
            inputs[i].ClearInput();
        }
    }
}
