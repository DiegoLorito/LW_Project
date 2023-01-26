using System;

[Serializable]
public class ResponseProgressPerType
{
    public int statusCode;
    public string message;
    public BEProgressPerType[] data;
    public BEError error;

}
