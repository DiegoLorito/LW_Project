using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DAUser
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_USER);

    public static IEnumerator Find(Action<ResponseUser, ErrorResponse> OnRequestFinished, string data = null, string value = null)
    {
        // data  - > id_user , id_client

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
            ResponseUser response = new ResponseUser();

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
                response = JsonUtility.FromJson<ResponseUser>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator Update(Action<ResponseUser, ErrorResponse> OnRequestFinished, BEUser user)
    {
        WWWForm form = new WWWForm();
        form.AddField("str_user_name", user.str_user_name);
        form.AddField("dte_birth_date", user.dte_birth_date);
        form.AddField("id_client", user.id_client);

        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH, user.id_user), myData))
        {
            yield return www.SendWebRequest();
            ResponseUser responseUser = new ResponseUser();

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
                responseUser = JsonUtility.FromJson<ResponseUser>(www.downloadHandler.text);
                OnRequestFinished.Invoke(responseUser, null);
            }
        }
    }

    public static IEnumerator Delete(Action<ResponseUser, ErrorResponse> OnRequestFinished, int id_user)
    {
        using (UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id_user)))
        {
            yield return www.SendWebRequest();
            ResponseUser responseUser = new ResponseUser();

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
                responseUser.statusCode = (int)www.responseCode;
                OnRequestFinished.Invoke(responseUser, null);
            }
        }
    }
   
    public static IEnumerator Create(Action<ResponseUserCreated, ErrorResponse> OnRequestFinished, BEUser user, int id_world, string str_current_unit_code, string str_current_avatar_code, string str_max_unit_code_unlocked)
    {
        WWWForm form = new WWWForm();
        form.AddField("dte_birth_date", user.dte_birth_date);
        form.AddField("id_client", user.id_client);
        form.AddField("id_world", id_world);
        form.AddField("str_user_name", user.str_user_name);
        form.AddField("str_current_unit_code", str_current_unit_code);
        form.AddField("str_max_unit_code_unlocked", str_max_unit_code_unlocked);
        form.AddField("str_current_avatar_code", str_current_avatar_code);

        form.AddField("dte_user_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        using (UnityWebRequest www = UnityWebRequest.Post(PATH, form))
        {
            yield return www.SendWebRequest();
            ResponseUserCreated response = new ResponseUserCreated();

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
                response = JsonUtility.FromJson<ResponseUserCreated>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

}
