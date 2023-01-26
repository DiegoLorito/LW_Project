using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class DAAuthentication
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_AUTHENTICATION);

    public static IEnumerator Login(Action<ResponseClient, ErrorResponse> OnRequestFinished,string str_client_email, string str_client_password)
    {
        WWWForm form = new WWWForm();
        form.AddField("str_client_email", str_client_email);
        form.AddField("str_client_password", str_client_password);

        using (UnityWebRequest www = UnityWebRequest.Post(PATH, form))
        {
            yield return www.SendWebRequest();
            ResponseClient response = new ResponseClient();
            //Debug.Log(www.downloadHandler.text);
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                OnRequestFinished.Invoke(null, new ErrorResponse(0, www.error));
            }
            else if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                OnRequestFinished.Invoke(null, new ErrorResponse(Convert.ToInt32(www.responseCode), www.error));
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                response = JsonUtility.FromJson<ResponseClient>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);                                                                                                          
            }
        }
    }

}
