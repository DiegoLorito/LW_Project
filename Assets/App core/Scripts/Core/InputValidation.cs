using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValidation : MonoBehaviour
{
    private InputField input;

    public int currentMonth;
    public int currentYear;


    private void Awake()
    {
        input = GetComponent<InputField>();
    }

    public void ValidateLength(int length)
    {
        if (input.text == "") return;

        if(input.text.Length < 2)
        {
            input.text = "0" + input.text;
        }
    }
    public void ValidateYear()
    {
        if (input.text == "") return;
 
        string text = input.text;

        if (text.Length < 4)
        {
            print("Error: Formato de año inválido");

            input.text = "";
            

        }
        else
        {
            print("Formato de año correcto");
            //GameEvents.InputYear(int.Parse(text));
        }
    }
    public void ValidateMonth()
    {
        if (input.text == "") return;

        int value = int.Parse(input.text);

        if(value < 1 || value > 12)
        {
            print("Error: Mes inválido");
            input.text = "";
        }
        else
        {
            //GameEvents.InputMonth(value);
        }

    }
    public void ValidateDay()
    {
        if (input.text == "") return;

        int value = int.Parse(input.text);
        int isLeapYear = 0;
        int daysInMonth = 0;

        if (currentYear % 4 == 0 && currentYear % 100 != 0) isLeapYear = 1;

        daysInMonth = (currentMonth == 2) ? (28 + isLeapYear) : 31 - (currentMonth - 1) % 7 % 2;


        if (value < 1 || value > daysInMonth)
        {
            input.text = "";
            print("Error: Día inválido");
        }
    }


    //public void InputMonth(int value)
    //{
    //    currentMonth = value;
    //}
    //public void InputYear(int value)
    //{
    //    currentYear = value;
    //}


    //private void OnDestroy()
    //{
    //    GameEvents.onInputMonth += InputMonth;
    //    GameEvents.onInputYear += InputYear;
    //}
}
