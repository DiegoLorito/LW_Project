using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DAUnlockedLand
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_UNLOCKED_LAND);

    public static async Task Find(Action<ResponseUnlockedLand, ErrorResponse> OnRequestFinished, int id_user_account = 0)
    {
        string queryParams;

        if (id_user_account <= 0)
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?id_user_account" + "=" + id_user_account;
        }

        UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponseUnlockedLand response = new ResponseUnlockedLand();

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
            response = JsonUtility.FromJson<ResponseUnlockedLand>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
    }

    public static async Task Create(Action<ResponseUnlockedLand, ErrorResponse> OnRequestFinished, BEUnlockedLand beUnlockedLand)
    {
        WWWForm form = new WWWForm();

        form.AddField("id_user_account", beUnlockedLand.id_user_account);
        form.AddField("str_unlocked_land_code", beUnlockedLand.str_unlocked_land_code);
        form.AddField("dte_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        UnityWebRequest www = UnityWebRequest.Post(PATH, form);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponseUnlockedLand response = new ResponseUnlockedLand();

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
            response = JsonUtility.FromJson<ResponseUnlockedLand>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
    }

    public static async Task Delete(Action<ResponseUnlockedLand, ErrorResponse> OnRequestFinished, int id_unlocked_land)
    {
        UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id_unlocked_land));
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponseUnlockedLand response = new ResponseUnlockedLand();

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
