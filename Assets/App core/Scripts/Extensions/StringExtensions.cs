using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensions
{
    public static string FirstCharToUpper(this string input)
    {
        char[] charArray = input.ToCharArray();

        Char.ToUpper(charArray[0]);

        string word = "";

        for (int i = 0; i < charArray.Length; i++)
        {
            word += charArray[i];
        }

        return word;
    }
}
