using System;

[Serializable]
public class ResponseProgress
{
    public int statusCode;
    public string message;
    public BEProgress[] data;
    public BEError error;
}

