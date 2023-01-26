using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class DAProgressUnitWorld
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_PROGRESS_UNIT_WORLD);

    public static IEnumerator Find(Action<ResponseProgressUnitWorld, ErrorResponse> OnRequestFinished, int id_user_account=0, int id_world=0)
    {
        string queryParams;

        if (id_user_account == 0 || id_world == 0)
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?id_user_account=" + id_user_account+ "&id_world="+ id_world;
        }

        using (UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams))
        {
            yield return www.SendWebRequest();
            ResponseProgressUnitWorld response = new ResponseProgressUnitWorld();

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
                response = JsonUtility.FromJson<ResponseProgressUnitWorld>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator Update(Action<ResponseProgressUnitWorld, ErrorResponse> OnRequestFinished, BEProgressUnitWorld beProgressUnitWorld)
    {
        WWWForm form = new WWWForm();
        form.AddField("id_world", beProgressUnitWorld.id_world);
        form.AddField("id_user_account", beProgressUnitWorld.id_user_account);
        form.AddField("str_current_unit_code", beProgressUnitWorld.str_current_unit_code);
        form.AddField("str_max_unit_code_unlocked", beProgressUnitWorld.str_max_unit_code_unlocked);
        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH), myData))
        {
            yield return www.SendWebRequest();
            ResponseProgressUnitWorld response = new ResponseProgressUnitWorld();

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
                response = JsonUtility.FromJson<ResponseProgressUnitWorld>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

}
