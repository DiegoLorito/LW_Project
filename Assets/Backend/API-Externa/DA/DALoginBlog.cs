using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DALoginBLog
{
    private static string PATH = string.Concat(Constants.BLOG_API, Constants.PATH_BLOG_LOGIN);

    public static async Task Login(Action<BELoginBlog, ErrorResponse> OnRequestFinished, string username,string password)
    {
        Utils.PrintStartTime("DALoginBLog");
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(PATH, form);
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();
    
        BELoginBlog response = new BELoginBlog();
        Debug.Log(www.result);

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            OnRequestFinished.Invoke(null, new ErrorResponse(0, www.error));
        }
        else if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.downloadHandler.text);
            BEErrorBlog errorResponse = new BEErrorBlog();
            errorResponse = JsonUtility.FromJson<BEErrorBlog>(www.downloadHandler.text);
            OnRequestFinished.Invoke(null, new ErrorResponse(Convert.ToInt32(www.responseCode), errorResponse.code));
        }
        else
        {
            response = JsonUtility.FromJson<BELoginBlog>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DALoginBLog");
    }
}
