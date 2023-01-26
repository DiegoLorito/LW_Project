using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{

    public enum TypeLog { Log, Warning, Error };

    public static void Logger(string className, string method, string message, TypeLog typeLog, bool logState, string color)
    {
        if (logState)
        {
            switch (typeLog)
            {
                case TypeLog.Log:
                    Debug.Log("<color=" + color + ">" + className + "_" + method + "_" + message + "</color>");
                    break;
                case TypeLog.Warning:
                    Debug.LogWarning("<color=" + color + ">" + className + "_" + method + "_" + message + "</color>");
                    break;
                case TypeLog.Error:
                    Debug.LogError("<color=" + color + ">" + className + "_" + method + "_" + message + "</color>");
                    break;
            }
        }
    }

    public static void Log(string color, string message, LogType logType, bool state)
    {
        if (state)
        {
            message = "<color=" + color + ">" + message + "</color>";

            switch (logType)
            {
                case LogType.Assert:
                    Debug.Log(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Error:
                    Debug.LogError(message);
                    break;
                default:
                    break;
            }

        }
    }

    public static float time;
    public static bool startCronometer=false;

    public void Update()
    {
        if (startCronometer)
        {
    
            
            time += Time.deltaTime;
        }
    }

    public static void PrintStartTime(string method)
    {
        time = 0;
        startCronometer = true;
        Debug.Log(method + " start: " + " " + time.ToString() + " cronometer");
    }

    public static void PrintEndTime(string method)
    {
        startCronometer = false;
        Debug.Log(method + " end: " + " " + time.ToString() + " cronometer");
    }


}