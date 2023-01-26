using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLogIn : AppScreen
{
    public InputField textClientEmail;
    public InputField textClientPassword;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            textClientEmail.text = "javier@brightloritos.net";
            textClientPassword.text = "pass1";
        }
    }
    public void LogIn()
    {
        if (textClientEmail.text == "" || textClientPassword.text == "") return;

        string email = textClientEmail.text;
        string pass = textClientPassword.text;

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            TransitionController.instance.RoutineTransitionIn(),
            DAAuthentication.Login(Authentication, email, pass),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    private void SaveClientDataOnJson()
    {
        ControladorData.instance.data = new AppJsonData();

        ControladorData.instance.data.client = AppServerData.instance.dataClient;
        ControladorData.instance.data.loggedIn = true;
        ControladorData.instance.SaveAppData();
    }
    private void FindAllUsers()
    {
        List<IEnumerator> routines = new List<IEnumerator>()
        {
            //DAReportUser.FindUsersProgress(FindUsers, AppServerData.instance.dataClient.id),
            RoutinesController.Action(SaveClientDataOnJson),
            RoutinesController.Action(()=> controller.ChangeAppScreen(3))
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }

    private void Authentication(ResponseClient response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            GameEvents.ConectionError(LogIn);
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    switch (response.code)
                    {
                        case 0: //Email not found
                            GameEvents.ConectionError(null,true, "Email not found", "Email not found, try Sign Up");
                            break;
                        case 1: // Password Incorrect
                            GameEvents.ConectionError(null, true,"Wrong Password", "Incorrect password");
                            break;
                        case 2: // Log in succesfull
                            GameEvents.LogIn(response);
                            StartCoroutine(DAReportUser.FindUsersProgress(FindUsers, AppServerData.instance.dataClient.id));
                            //GameEvents.ConectionError(LogIn);
                            break;
                        default:
                            Debug.Log("Response code: " + response.statusCode);
                            GameEvents.ConectionError(LogIn);
                            break; 
                    }
                    break;
                case 204:
                    Debug.Log($"Conection error: {response.statusCode}");
                    GameEvents.ConectionError(LogIn);
                    break;
                case 400: 
                    Debug.Log($"Conection error: {response.statusCode}");
                    GameEvents.ConectionError(LogIn);
                    break;
                default:
                    Debug.Log($"Conection error: {response.statusCode}");
                    GameEvents.ConectionError(LogIn);
                    break;
            }
        }
    }
    private void FindUsers(ResponseReportUser response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            GameEvents.ConectionError(LogIn);
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    GameEvents.UsersFound(response);
                    FindAllUsers();
                    break;

                case 204:
                    GameEvents.UsersFound(response);
                    FindAllUsers();
                    break;
                case 400:
                    GameEvents.ConectionError(LogIn);
                    break;

                default:
                    Debug.Log("Response code: " + response.statusCode);
                    break;
            }
        }
    }

}
