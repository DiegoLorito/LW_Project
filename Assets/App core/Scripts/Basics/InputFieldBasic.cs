using System;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldBasic : InputBasic
{
    public InputField input;

    public Image trailIcon;
    public Sprite trailIconSprite;

    public void ValidateInputFilled()
    {
        completed = (input.text != null && input.text != "");
        stringValue = input.text;
    }
    public void ValidateEmailFilled()
    {
        if (input.text.Contains("@") && input.text.Length > 4)
        {
            int atIndex = input.text.IndexOf("@");
            int lenght = input.text.Length;

            string aux = input.text.Substring(atIndex, lenght - atIndex);

            completed = aux.Contains(".") && (aux.IndexOf(".") != aux.Length - 1);

            stringValue = input.text;
        }
        else
        {
            completed = false;
        }
    }
    public void ValidatePasswordFilled(CheckList checkList)
    {
        if (input == null && input.text == "") return;
        
        //========== At least 8 characters
        checkList.SetItemStatus(0, ValidateCharacters(input.text, 8));

        //========== At least 1 Uppercase letter
        checkList.SetItemStatus(1, ValidateUpperCases(input.text));

        //========== At least 3 numbers
        checkList.SetItemStatus(2, ValidateDigits(input.text, 3));

        stringValue = input.text;
        completed = checkList.isComplete();
    }
    public void ValidateInputMatch(InputFieldBasic _field)
    {
        completed = _field.input.text == input.text;
        _field.completed = completed;
    }
    public void ValidateDigits(int minimun)
    {
        if (input.text.Length < minimun)
        {
            int digits = minimun - input.text.Length;

            for (int i = 0; i < digits; i++)
            {
                input.text = "0" + input.text; 
            }
        }
    }

    //=========== PASSWORD VALIDATIONS
    private bool ValidateCharacters(string text,int amount)
    {
        return text.Length >= amount;
    }
    private bool ValidateUpperCases(string text, int amount = 1)
    {
        int currAmount = 0;

        Char[] charArray = text.ToCharArray();

        for (int i = 0; i < charArray.Length; i++)
        {
            if (Char.IsUpper(charArray[i]))
            {
                currAmount++;
            }

            if (currAmount == amount) return true;
        }

        return false;
    }
    private bool ValidateDigits(string text, int amount = 1)
    {
        int currAmount = 0;

        Char[] charArray = text.ToCharArray();

        for (int i = 0; i < charArray.Length; i++)
        {
            if (Char.IsDigit(charArray[i]))
            {
                currAmount++;
            }

            if (currAmount == amount) return true;
        }

        return false;
    }
    public void ShowPassword(Sprite sprite)
    {
        if (input.contentType == InputField.ContentType.Password)
        {
            trailIcon.sprite = sprite;
            input.contentType = InputField.ContentType.Standard;
        }
        else
        {
            trailIcon.sprite = trailIconSprite;
            input.contentType = InputField.ContentType.Password;
        }

        input.ForceLabelUpdate();
    }
    public override void ClearInput()
    {
        input.text = "";
    }

    //=========== INPUT EVENTS
    public void NextInputFieldBasic(InputFieldBasic inputField)
    {
        //if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) Debug.Log("A"); 
        ////if (Input.GetKeyDown(KeyCode.Return) && ) inputField.input.Select();
    }
    public void ClickButton(UnityEngine.UI.Button button)
    {
        if (Input.GetKeyDown(KeyCode.Return)) button.onClick.Invoke();
    }

}
