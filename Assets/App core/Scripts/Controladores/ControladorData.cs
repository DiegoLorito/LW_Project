using UnityEngine;
using System.IO;

public class ControladorData : MonoBehaviour
{
    public bool development;

    public static ControladorData instance;

    [HideInInspector] public AppJsonData data;
    [HideInInspector] public bool unitsLoaded; 
    [HideInInspector] public bool usersLoaded;
    [HideInInspector] public Color unitColor;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        print(Application.persistentDataPath);

        LoadAppData();
    }

    public void SaveAppData()
    {
        if (development) return;

        string json = JsonUtility.ToJson(data);
        CreateTextFile(json);
    }
    public void LoadAppData()
    {
        //diego@brightloritos.net
        //pass1
        //id_client 36

        if (development)
        {
            data = new AppJsonData();
            data.client.id = 36;
            data.client.name = "Test Bot";
            data.loggedIn = true;
            data.userSelected = false;
            return;
        }

        if (ReadText() == null)
        {
            data = null;
            print("No hay datos");
        }
        else
        {
            string json = ReadText();
            JsonUtility.FromJsonOverwrite(json, data);
        }
    }
    private void CreateTextFile(string text)
    {
        string path = Application.persistentDataPath + "/appData.txt";
        File.WriteAllText(path, text);
    }
    private string ReadText()
    {
        string path = Application.persistentDataPath + "/appData.txt";

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            //reader.Close();

            return reader.ReadToEnd();
        }
        else
        {
            return null;
        }
    }



    public bool isOnUnit()
    {
        return data.userSelected;
    }

    //===== COMPARE USERS =====//
    public bool CompareUsers(UserData _user)
    {
        return _user.id == data.user.id;
    }

    //===== CHECK DATA =====//
    public bool isLogged()
    {
        return (data != null) && (data.loggedIn);
    }

}

[System.Serializable]
public class AppJsonData
{
    public ClientData client = new ClientData();
    public UserData user = new UserData();

    public bool loggedIn;
    public bool userSelected;
}
