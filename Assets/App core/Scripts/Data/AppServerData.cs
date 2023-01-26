using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppServerData: MonoBehaviour
{
    public static AppServerData instance;

    public ClientData dataClient;
    public UserData dataCurrentUser;

    public List<UserData> users;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        GameEvents.onLogIn += LogInSuccessful;
        GameEvents.onSignInSuccessful += SignInSuccessful;
        GameEvents.onUsersFound += UsersFound;
        GameEvents.onConectionError += ConectionError;
        GameEvents.onCreateUser += CreateUser;
    }

    public bool CurrentUnitIsCompleted()
    {
        return dataCurrentUser.indexCurUnit < dataCurrentUser.indexMaxUnit;
    }

    private void LogInSuccessful(ResponseClient response)
    {
        dataClient = new ClientData();

        dataClient.id = response.data.id_client;
        dataClient.name = response.data.str_client_name;
        dataClient.lastName = response.data.str_client_lastname;
        dataClient.email = response.data.str_client_email;
        dataClient.password = response.data.str_client_password;
        dataClient.premiun = response.data.bool_premiun_account;
    }
    private void SignInSuccessful(ResponseClientID response)
    {
        dataClient = new ClientData();

        dataClient.id = response.data;
    }
    private void UsersFound(ResponseReportUser response)
    {
        users = new List<UserData>();

        if (response.data != null)
        {
            for (int i = 0; i < response.data.Length; i++)
            {
                UserData user = new UserData(response.data[i]);
                users.Add(user);
            }
        }

    }

    public void UpdateClient(ClientData data)
    {
        dataClient.Update(data);
    }
    public void CreateUser(UserData data)
    {
        users.Add(data);
    }
    public void UpdateUser(UserData user)
    {
        users.Find(x => x.id == user.id).Update(user);
    }
    public void RestartUser(UserData user)
    {
        users.Find(x => x.id == user.id).Restart();
    }
    public void RemoveUser(int idUser)
    {
        UserData user = users.Find(x => x.id == idUser);
        users.Remove(user);

        dataCurrentUser = users[0];
    }

    public void ConectionError(System.Action action, bool simple,string errorCode = "", string errorInfo = "")
    {
        RoutinesController.error = true;
        GameEvents.ShowErrorDialog(action,simple, errorCode, errorInfo);
    }
    private void OnDestroy()
    {
        GameEvents.onLogIn -= LogInSuccessful;
        GameEvents.onSignInSuccessful -= SignInSuccessful;
        GameEvents.onUsersFound -= UsersFound;
        GameEvents.onConectionError -= ConectionError;
    }

}
