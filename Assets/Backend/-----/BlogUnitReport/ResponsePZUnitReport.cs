using System;

[Serializable]
public class ResponsePZUnitReport
{
    public int statusCode;
    public string message;
    public BEPZUnitReport[] data;
    public BEError error;
}
