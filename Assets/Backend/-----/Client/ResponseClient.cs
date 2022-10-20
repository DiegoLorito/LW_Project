using System;

[Serializable]
public class ResponseClient
{
    public int statusCode;
    public string message;
    public BEClient data;
    public BEError error;
    public int code;

}

public class ResponseClientID
{
    public int statusCode;
    public string message;
    public int data;
    public BEError error;
}

