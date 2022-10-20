using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DARewardsCollected
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_REWARDS_COLLECTED);

    public static async Task Find(Action<ResponseRewardsCollected, ErrorResponse> OnRequestFinished, int id_user_account)
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

        ResponseRewardsCollected response = new ResponseRewardsCollected();

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
            response = JsonUtility.FromJson<ResponseRewardsCollected>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
    }

    public static async Task Create(Action<ResponseRewardsCollected, ErrorResponse> OnRequestFinished, BERewardsCollected beRewardsCollected)
    {
        WWWForm form = new WWWForm();

        form.AddField("id_user_account", beRewardsCollected.id_user_account);
        form.AddField("str_rewards_code", beRewardsCollected.str_rewards_code);
        form.AddField("str_rewards_category", beRewardsCollected.str_rewards_category);
        form.AddField("dte_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        UnityWebRequest www = UnityWebRequest.Post(PATH, form);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponseRewardsCollected response = new ResponseRewardsCollected();

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
            response = JsonUtility.FromJson<ResponseRewardsCollected>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
    }

    public static async Task Delete(Action<ResponseRewardsCollected, ErrorResponse> OnRequestFinished, int id_rewards_collected)
    {
        UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id_rewards_collected));
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponseRewardsCollected response = new ResponseRewardsCollected();

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
