using System;

[Serializable]
public class ResponseUser
{
    public int statusCode;
    public string message;
    public BEUser[] data;
    public BEError error;
}

[Serializable]
public class ResponseUserCreated
{
    public int statusCode;
    public string message;
    public int id_user_account;
    public int id_user;
    public BEError error;
}

