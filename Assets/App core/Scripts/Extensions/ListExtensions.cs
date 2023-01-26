//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void EnableItemList<T>(this IList<T> list, bool enable) where T : MonoBehaviour
    {
        if (list == null) return;

        for (int i = 0; i < list.Count; i++)
        {
            try
            {
                list[i].gameObject.SetActive(enable);
            }
            catch (Exception e)
            {
                Debug.LogWarning(list[i].name + " does not contain GameObject property, ERROR: " + e);
            }
        }
    }
    public static void AddItems<T>(this IList<T> list,T item, int amount) where T : MonoBehaviour
    {
        if (list == null) return;

        for (int i = 0; i < amount; i++)
        {
            list.Add(item);
        }
    }
    public static void AddItemsPooling<T>(this IList<T> list, int totalAmount, T item) where T : MonoBehaviour
    {
        if (list == null) list = new List<T>();

        if(totalAmount > list.Count)
        {
            int difference = totalAmount - list.Count;

            for (int i = 0; i < difference; i++)
            {
                list.Add(item);
            }
        }
    }

}
