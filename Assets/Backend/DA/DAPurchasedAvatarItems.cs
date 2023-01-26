using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DAPurchasedAvatarItems : MonoBehaviour
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_AVATAR_LAND_ITEMS);

    public static async Task GetPurchasedAvatarItems(Action<ResponsePurchasedAvatarItems, ErrorResponse> OnRequestFinished, int id_user_account = 0)
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

        ResponsePurchasedAvatarItems response = new ResponsePurchasedAvatarItems();

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
            response = JsonUtility.FromJson<ResponsePurchasedAvatarItems>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
    }

    public static async Task BuyAvatarItem(Action<ResponsePurchasedAvatarItems, ErrorResponse> OnRequestFinished, int id_user_account, string item_code)
    {
        WWWForm form = new WWWForm();

        form.AddField("id_user_account", id_user_account);
        form.AddField("str_avatar_item_code", item_code);
        form.AddField("dte_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        UnityWebRequest www = UnityWebRequest.Post(PATH, form);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponsePurchasedAvatarItems response = new ResponsePurchasedAvatarItems();

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
            response = JsonUtility.FromJson<ResponsePurchasedAvatarItems>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
    }

    public static async Task Delete(Action<ResponsePurchasedAvatarItems, ErrorResponse> OnRequestFinished, int id_purchased_land_items)
    {
        UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id_purchased_land_items));
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponsePurchasedAvatarItems response = new ResponsePurchasedAvatarItems();

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
