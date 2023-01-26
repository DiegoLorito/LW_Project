using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DAProgressPerType
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_PROGRESS_PER_TYPE);

    public static async Task SearchByWorld(Action<ResponseProgressPerType, ErrorResponse> OnRequestFinished, int id_user_account, int id_world)
    {
        Utils.PrintStartTime("DAProgressPerType SearchByWorld");
        string queryParams = "?id_user_account" + "=" + id_user_account + "&id_world=" + id_world;

        UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();
        while (!www.isDone)
            await Task.Yield();

        ResponseProgressPerType response = new ResponseProgressPerType();

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
            response = JsonUtility.FromJson<ResponseProgressPerType>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DAProgressPerType SearchByWorld");
    }

    public static async Task SearchByUnitCode(Action<ResponseProgressPerType, ErrorResponse> OnRequestFinished, int id_user_account, string str_unit_code, int id_world)
    {
        Utils.PrintStartTime("DAProgressPerType SearchByUnitCode");
        string queryParams = "?id_user_account" + "=" + id_user_account + "&str_unit_code=" + str_unit_code + "&id_world=" + id_world;

        UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponseProgressPerType response = new ResponseProgressPerType();

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
            response = JsonUtility.FromJson<ResponseProgressPerType>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DAProgressPerType SearchByUnitCode");
    }
}
