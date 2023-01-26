using System;

[Serializable]
public class ErrorResponse
{
    public ErrorResponse(int code, string message)
    {
        this.code = code;
        this.message = message;
    }

    public int code;
    public string message;
}

