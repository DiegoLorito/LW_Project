using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class DAProgress
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_PROGRESS);

    public static IEnumerator Find(Action<ResponseProgress, ErrorResponse> OnRequestFinished, string data = null, string value = null)
    {
        // data  - > id_progress , id_content , id_user_account

        string queryParams;

        if (data == null || value == null)
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?" + data + "=" + value;
        }

        using (UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams))
        {
            yield return www.SendWebRequest();
            ResponseProgress response = new ResponseProgress();

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
                Debug.Log(www.downloadHandler.text);
                response = JsonUtility.FromJson<ResponseProgress>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator Create(Action<ResponseProgress, ErrorResponse> OnRequestFinished, BEProgress beProgress)
    {
        WWWForm form = new WWWForm();

        form.AddField("id_content", beProgress.str_content_code);
        form.AddField("id_user_account", beProgress.id_user_account);
        form.AddField("tm_content_time", beProgress.tm_content_time);
        form.AddField("dte_progress_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
     
        using (UnityWebRequest www = UnityWebRequest.Post(PATH, form))
        {
            yield return www.SendWebRequest();
            ResponseProgress response = new ResponseProgress();

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
                response = JsonUtility.FromJson<ResponseProgress>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator Update(Action<ResponseProgress, ErrorResponse> OnRequestFinished, BEProgress beProgress)
    {
        WWWForm form = new WWWForm();
        form.AddField("tm_content_time", beProgress.tm_content_time);
        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH, beProgress.id_progress), myData))
        {
            yield return www.SendWebRequest();
            ResponseProgress response = new ResponseProgress();

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
                response = JsonUtility.FromJson<ResponseProgress>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator Delete(Action<ResponseProgress, ErrorResponse> OnRequestFinished, int id)
    {
        using (UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id)))
        {
            yield return www.SendWebRequest();
            ResponseProgress response = new ResponseProgress();

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
                response.statusCode = (int)www.responseCode;
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

}
