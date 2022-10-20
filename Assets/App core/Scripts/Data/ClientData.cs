//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

[System.Serializable]
public class ClientData
{
    public int id;
    public string name;
    public string lastName;
    public string email;
    public string password;
    public bool premiun;

    [UnityEngine.Header("Ludik Data")]
    [UnityEngine.HideInInspector] public string ludikEmail;
    [UnityEngine.HideInInspector] public string ludikNicename;
    [UnityEngine.HideInInspector] public string ludikDisplayName;
    [UnityEngine.HideInInspector] public string ludikToken;

    public ClientData(ClientData data = null)
    {
        if (data == null) return;

        this.id = data.id;
        this.name = data.name;
        this.lastName = data.lastName;
        this.email = data.email;
        this.password = data.password;
        this.premiun = data.premiun;
    }

    public void SetLudikData(BELoginBlog response = null)
    {
        if (response == null) return;

        this.ludikDisplayName = response.user_display_name;
        this.ludikEmail = response.user_email;
        this.ludikNicename = response.nicename;
        this.ludikToken = response.token;
    }
    public void Update(ClientData data)
    {
        this.id = data.id;
        this.name = data.name;
        this.lastName = data.lastName;
        this.email = data.email;
        this.premiun = data.premiun;
    }
}
