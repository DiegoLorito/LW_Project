using System;

[Serializable]
public class ResponseUserAccount
{
    public int statusCode;
    public string message;
    public BEUserAccount[] data;
    public BEError error;
}

