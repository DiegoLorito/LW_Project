using System;

[Serializable]
public class ResponseReportContent
{
    public int statusCode;
    public string message;
    public BEReportContent[] data;
    public BEError error;
}

