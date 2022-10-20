using System;

[Serializable]
public class BEErrorBlog
{
    public string code;
    public string message;
    public Data data;
}

[Serializable]
public class ErrorResponseBlog
{
    public ErrorResponseBlog(string code, string message, int errorCode)
    {
        this.code = code;
        this.message = message;
        this.errorCode = errorCode;
    }

    public string code;
    public string message;
    public int errorCode;
}

public class Data
{
    public int status;
}