using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DARegister
{
    private static string PATH = string.Concat(Constants.BLOG_API, Constants.PATH_BLOG_REGISTER);

    public static async Task Register(Action<BERegisterResponse, ErrorResponse> OnRequestFinished, string username, string email, string password)
    {
        Utils.PrintStartTime("DARegister");
        BERegister beRegister = new BERegister();
        beRegister.username = username;
        beRegister.email = email;
        beRegister.password = password;

        byte[] myData =Encoding.UTF8.GetBytes(JsonUtility.ToJson(beRegister));
        UnityWebRequest www = UnityWebRequest.Post(PATH, JsonUtility.ToJson(beRegister));
        www.uploadHandler = new UploadHandlerRaw(myData);

        www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
        www.SendWebRequest();


        while (!www.isDone)
            await Task.Yield();

        BERegisterResponse response = new BERegisterResponse();

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
            response = JsonUtility.FromJson<BERegisterResponse>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DARegister");
    }
}
