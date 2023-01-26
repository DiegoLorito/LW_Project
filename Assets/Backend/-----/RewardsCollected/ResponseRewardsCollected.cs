using System;

[Serializable]
public class ResponseRewardsCollected 
{
    public int statusCode;
    public string message;
    public BERewardsCollected[] data;
    public BEError error;
}
