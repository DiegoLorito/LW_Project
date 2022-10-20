using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DALastRewards 
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_LAST_REWARDS);

    public static async Task Find(Action<ResponseLastRewards, ErrorResponse> OnRequestFinished, int id_user_account)
    {
        Utils.PrintStartTime("DALastRewards");

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

        ResponseLastRewards response = new ResponseLastRewards();

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
            response = JsonUtility.FromJson<ResponseLastRewards>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DALastRewards");
    }

}
