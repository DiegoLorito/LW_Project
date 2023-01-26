using System;

[Serializable]
public class ResponseAppStatus { 
    public int statusCode;
    public string message;
    public BEAppStatus[] data;
    public BEError error;
}

