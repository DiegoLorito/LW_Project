using System;

[Serializable]
public class ResponsePurchasedLandItems 
{
    public int statusCode;
    public string message;
    public BEPurchasedLandItems[] data;
    public BEError error;
}
