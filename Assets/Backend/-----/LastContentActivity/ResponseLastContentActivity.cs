using System;

[Serializable]
public class ResponseLastContentActivity
{
    public int statusCode;
    public string message;
    public BELastContentActivity[] data;
    public BEError error;
}
