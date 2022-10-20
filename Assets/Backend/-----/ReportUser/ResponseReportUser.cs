using System;

[Serializable]
public class ResponseReportUser
{
    public int statusCode;
    public string message;
    public BEReportUser[] data;
    public BEError error;
}

