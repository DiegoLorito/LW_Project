using System;

[Serializable]
public class ResponseLastRewards
{
    public int statusCode;
    public string message;
    public BELastRewards[] data;
    public BEError error;
}
