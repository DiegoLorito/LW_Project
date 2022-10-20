using System;
using System.Collections;
using UnityEngine;

public static class RoutinesController
{
    public static bool error;
    public static IEnumerator MultipleRoutines(params IEnumerator[] routines)
    {

        for (int i = 0; i < routines.Length; i++)
        {

            while (routines[i].MoveNext())
            {
                yield return routines[i].Current;
            }

            if (error)
            {
                error = false;
                yield break;
            }
        }

        yield break;
    }
    public static IEnumerator Action(Action action, float delay = 0)
    {
        action();
        yield return new WaitForSeconds(delay);
        yield break;
    }

}
