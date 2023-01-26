using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLogIn : MonoBehaviour
{
    private void Authentication(ResponseClient response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            //GameEvents.ConectionError(LogIn);
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    switch (response.code)
                    {
                        case 0: //Email not found
                            GameEvents.ConectionError(null, true, "Email not found", "Email not found, try Sign Up");
                            break;
                        case 1: // Password Incorrect
                            GameEvents.ConectionError(null, true, "Wrong Password", "Incorrect password");
                            break;
                        case 2: // Log in succesfull
                            GameEvents.LogIn(response);
                            break;
                        default:
                            Debug.Log("Response code: " + response.statusCode);
                            //GameEvents.ConectionError(LogIn);
                            break;
                    }
                    break;
                case 204:
                    Debug.Log($"Conection error: {response.statusCode}");
                    //GameEvents.ConectionError(LogIn);
                    break;
                case 400:
                    Debug.Log($"Conection error: {response.statusCode}");
                    //GameEvents.ConectionError(LogIn);
                    break;
                default:
                    Debug.Log($"Conection error: {response.statusCode}");
                    //GameEvents.ConectionError(LogIn);
                    break;
            }
        }
    }
}
