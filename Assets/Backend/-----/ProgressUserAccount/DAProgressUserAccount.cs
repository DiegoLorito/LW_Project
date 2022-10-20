using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class DAProgressUserAccount
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_PROGRESS_USER_ACCOUNT);

    public static IEnumerator CreateProgressUpdateCoins(Action<ResponseProgressUserAccount, ErrorResponse> OnRequestFinished, BEProgressUserAccount be)
    {
        Debug.Log("CREANDO PROGRESO");

        WWWForm form = new WWWForm();

        form.AddField("id_user_account", be.id_user_account);
        form.AddField("str_content_code", be.str_content_code);
        form.AddField("str_unit_code", be.str_unit_code);
        form.AddField("id_world", be.id_world);
        form.AddField("tm_content_time", be.tm_content_time);
        form.AddField("int_user_account_coins", be.int_user_account_coins);
        form.AddField("dte_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        using (UnityWebRequest www = UnityWebRequest.Post(PATH, form))
        {
            yield return www.SendWebRequest();
            ResponseProgressUserAccount response = new ResponseProgressUserAccount();

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
                response = JsonUtility.FromJson<ResponseProgressUserAccount>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }


}
