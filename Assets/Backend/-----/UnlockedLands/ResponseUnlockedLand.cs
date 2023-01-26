using System;

[Serializable]
public class ResponseUnlockedLand
{
    public int statusCode;
    public string message;
    public BEUnlockedLand[] data;
    public BEError error;
}
