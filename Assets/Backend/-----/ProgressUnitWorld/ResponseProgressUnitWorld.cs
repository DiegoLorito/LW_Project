using System;

[Serializable]
public class ResponseProgressUnitWorld
{
    public int statusCode;
    public string message;
    public BEProgressUnitWorld[] data;
    public BEError error;
    public Action action;
}
