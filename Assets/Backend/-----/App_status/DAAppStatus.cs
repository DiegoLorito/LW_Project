using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DAAppStatus
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_APP_STATUS);

    public static IEnumerator Find(Action<ResponseAppStatus, ErrorResponse> OnRequestFinished)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(PATH))
        {
            yield return www.SendWebRequest();
            ResponseAppStatus response = new ResponseAppStatus();

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
                response = JsonUtility.FromJson<ResponseAppStatus>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

}
