using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBCallbacks : MonoBehaviour
{
    public static void UpdateAvatarColor(ResponseUserAccount response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            GameEvents.UpdateUserResponse(false);
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    GameEvents.UpdateUserResponse(true);
                    break;
                case 204:
                    GameEvents.UpdateUserResponse(false);
                    break;
                case 400:
                    GameEvents.UpdateUserResponse(false);
                    break;
                default:
                    GameEvents.UpdateUserResponse(false);
                    break;
            }
        }
    }

    public static void FindUserAccount(ResponseUserAccount response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            ErrorResponse("404", "Connection error");
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    GameEvents.UserAccountFound(response);
                    break;
                case 204: //Response vacio pero si se hace la consulta
                    ErrorResponse("204", "Not User Account found");
                    break;
                case 400: //Por error de parametro no se hace la consulta
                    ErrorResponse("400", "Wrong parameter was passed");
                    break;

                default:
                    Debug.Log("Response code: " + response.statusCode);
                    break;
            }
        }
    }
    public static void FindContentProgress(ResponseReportContent response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            ErrorResponse("404", "Connection error");
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    GameEvents.ContentProgressFound(response);
                    break;

                case 204: //Response vacio pero si se hace la consulta
                    GameEvents.ContentProgressFound(response);
                    //ErrorResponse("204", "Content report not found");
                    break;
                case 400: //Por error de parametro no se hace la consulta
                    ErrorResponse("400", "Wrong parameter was passed");
                    break;

                default:
                    Debug.Log("Response code: " + response.statusCode);
                    break;
            }
        }
    }
    public static void CreateProgressUpdateCoins(ResponseProgressUserAccount response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            ErrorResponse("404", "Connection error");
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    Debug.Log("Progress Created");
                    //GameEvents.ProgressCreated(response);
                    break;

                case 204: //Response vacio pero si se hace la consulta
                    ErrorResponse("204", "Create Progress - Some parameters not found");
                    break;
                case 400: //Por error de parametro no se hace la consulta
                    ErrorResponse("400", "Wrong parameter was passed");
                    break;

                default:
                    Debug.Log("Response code: " + response.statusCode);
                    break;
            }
        }
    }
    public static void UpdateProgressUnitWorld(ResponseProgressUnitWorld response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            ErrorResponse("404", "Connection error");
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    print("Progreso Unidad-Mundo actualizado");
                    //GameEvents.ProgressCreated(response);
                    break;

                case 204: //Response vacio pero si se hace la consulta
                    ErrorResponse("204", "Create Progress - Some parameters not found");
                    break;
                case 400: //Por error de parametro no se hace la consulta
                    ErrorResponse("400", "Wrong parameter was passed");
                    break;

                default:
                    Debug.Log("Response code: " + response.statusCode);
                    break;
            }
        }
    }



    public static void ErrorResponse(string errorCode, string errorInfo)
    {
        RoutinesController.error = true;
        //GameEvents.ShowErrorDialog(errorCode, errorInfo);
    }

    //public static void Callback
}
