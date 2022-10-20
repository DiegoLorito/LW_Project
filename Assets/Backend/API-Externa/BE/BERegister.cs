using System;

[Serializable]
public class BERegisterResponse 
{
    public int code;
    public string message;
}

public class BERegister
{
    public string username;
    public string email;
    public string password;
}
