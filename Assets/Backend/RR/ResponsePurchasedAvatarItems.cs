using System;

[Serializable]
public class ResponsePurchasedAvatarItems
{
    public int statusCode;
    public string message;
    public BEPurchasedAvatarItems[] data;
    public BEError error;
}
