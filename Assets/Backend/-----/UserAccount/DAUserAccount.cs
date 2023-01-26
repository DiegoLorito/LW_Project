using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class DAUserAccount
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_USER_ACCOUNT);

    public static IEnumerator Find(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, string data = null, string value = null)
    {
        // data  - > id_user_account , id_user

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
            ResponseUserAccount response = new ResponseUserAccount();

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
                response = JsonUtility.FromJson<ResponseUserAccount>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator UpdateAvatarDressedItems(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, string json_avatar_dressed_items, int id_user_account)
    {
        WWWForm form = new WWWForm();
        form.AddField("json_avatar_dressed_items", json_avatar_dressed_items);
        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH, id_user_account), myData))
        {
            yield return www.SendWebRequest();
            ResponseUserAccount responseUserAccount = new ResponseUserAccount();

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
                responseUserAccount = JsonUtility.FromJson<ResponseUserAccount>(www.downloadHandler.text);
                OnRequestFinished.Invoke(responseUserAccount, null);
            }
        }
    }

    public static IEnumerator UpdateCoins(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, int coins, int id_user_account)
    {
        WWWForm form = new WWWForm();
        form.AddField("int_user_account_coins", coins);
        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH, id_user_account), myData))
        {
            yield return www.SendWebRequest();
            ResponseUserAccount responseUserAccount = new ResponseUserAccount();

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
                responseUserAccount = JsonUtility.FromJson<ResponseUserAccount>(www.downloadHandler.text);
                OnRequestFinished.Invoke(responseUserAccount, null);
            }
        }
    }

    public static IEnumerator UpdateAvatarColor(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, string str_current_avatar_code, int id_user_account)
    {
        WWWForm form = new WWWForm();
        form.AddField("str_current_avatar_code", str_current_avatar_code);
        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH, id_user_account), myData))
        {
            yield return www.SendWebRequest();
            ResponseUserAccount responseUserAccount = new ResponseUserAccount();

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
                responseUserAccount = JsonUtility.FromJson<ResponseUserAccount>(www.downloadHandler.text);
                OnRequestFinished.Invoke(responseUserAccount, null);
            }
        }
    }

    public static IEnumerator UpdateUserAccountWorld(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, int int_current_id_world, int id_user_account)
    {
        WWWForm form = new WWWForm();
        form.AddField("int_current_id_world", int_current_id_world);
        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH, id_user_account), myData))
        {
            yield return www.SendWebRequest();
            ResponseUserAccount responseUserAccount = new ResponseUserAccount();

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
                responseUserAccount = JsonUtility.FromJson<ResponseUserAccount>(www.downloadHandler.text);
                OnRequestFinished.Invoke(responseUserAccount, null);
            }
        }
    }

}

//public IEnumerator Delete(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, int id)
//{
//    using (UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id)))
//    {
//        yield return www.SendWebRequest();
//        ResponseUserAccount responseUserAccount = new ResponseUserAccount();

//        if (www.result == UnityWebRequest.Result.ConnectionError)
//        {
//            OnRequestFinished.Invoke(null, new ErrorResponse(0, www.error));
//        }
//        else if (www.result == UnityWebRequest.Result.ProtocolError)
//        {
//            OnRequestFinished.Invoke(null, new ErrorResponse(Convert.ToInt32(www.responseCode), www.error));
//        }
//        else
//        {
//            responseUserAccount.statusCode = (int)www.responseCode;
//            OnRequestFinished.Invoke(responseUserAccount, null);
//        }
//    }
//}

//public IEnumerator Create(Action<ResponseUserAccount, ErrorResponse> OnRequestFinished, BEUserAccount beUserAccount)
//{
//    WWWForm form = new WWWForm();

//    form.AddField("id_user", beUserAccount.id_user);
//    form.AddField("int_user_account_coins", beUserAccount.int_user_account_coins);
//    form.AddField("dte_user_account_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

//    using (UnityWebRequest www = UnityWebRequest.Post(PATH, form))
//    {
//        yield return www.SendWebRequest();
//        ResponseUserAccount responseUserAccount = new ResponseUserAccount();

//        if (www.result == UnityWebRequest.Result.ConnectionError)
//        {
//            OnRequestFinished.Invoke(null, new ErrorResponse(0, www.error));
//        }
//        else if (www.result == UnityWebRequest.Result.ProtocolError)
//        {
//            OnRequestFinished.Invoke(null, new ErrorResponse(Convert.ToInt32(www.responseCode), www.error));
//        }
//        else
//        {
//            responseUserAccount = JsonUtility.FromJson<ResponseUserAccount>(www.downloadHandler.text);
//            OnRequestFinished.Invoke(responseUserAccount, null);
//        }
//    }
//}