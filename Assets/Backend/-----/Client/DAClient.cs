using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class DAClient
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_CLIENT);

    public static IEnumerator Find(Action<ResponseClient, ErrorResponse> OnRequestFinished,string data=null,string value=null)
    {
        // data  - > id_client , str_client_email 

        string queryParams;

        if (data==null || value == null)
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?" + data + "=" + value;
        }

        using (UnityWebRequest www = UnityWebRequest.Get(PATH+ queryParams))
        {
            yield return www.SendWebRequest();
            ResponseClient response = new ResponseClient();

            if (www.result==UnityWebRequest.Result.ConnectionError)
            {
                OnRequestFinished.Invoke(null, new ErrorResponse(0, www.error));
            }
            else if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                OnRequestFinished.Invoke(null, new ErrorResponse(Convert.ToInt32(www.responseCode), www.error));
            }
            else
            {
                response = JsonUtility.FromJson<ResponseClient>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

    public static IEnumerator Create(Action<ResponseClientID, ErrorResponse> OnRequestFinished, BEClient client)
    {
        WWWForm form = new WWWForm();

        form.AddField("str_client_name", client.str_client_name);
        form.AddField("str_client_lastname", client.str_client_lastname);
        form.AddField("str_client_email", client.str_client_email);
        form.AddField("str_client_password", client.str_client_password);
        form.AddField("dte_start_free_trial", client.dte_start_free_trial);
        form.AddField("bool_premiun_account", Convert.ToInt32(client.bool_premiun_account));
        form.AddField("dte_client_creation_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        using (UnityWebRequest www = UnityWebRequest.Post(PATH, form))
        {
            yield return www.SendWebRequest();
            ResponseClientID response = new ResponseClientID();

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
                response = JsonUtility.FromJson<ResponseClientID>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }
  
    public static IEnumerator Update(Action<ResponseClient, ErrorResponse> OnRequestFinished, BEClient client)
    {
        WWWForm form = new WWWForm();
        form.AddField("int_client_id", client.id_client);
        form.AddField("str_client_name", client.str_client_name);
        form.AddField("str_client_lastname", client.str_client_email);
        form.AddField("str_client_email", client.str_client_email);
        form.AddField("str_client_password", client.str_client_password);
        form.AddField("dte_start_free_trial", client.dte_start_free_trial);
        form.AddField("bool_premiun_account", System.Convert.ToInt32(client.bool_premiun_account));

        byte[] myData = form.data;

        using (UnityWebRequest www = UnityWebRequest.Put(string.Concat(PATH), myData))
        {
            yield return www.SendWebRequest();
            ResponseClient response = new ResponseClient();

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
                response = JsonUtility.FromJson<ResponseClient>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }
 
    public static IEnumerator Delete(Action<ResponseClient, ErrorResponse> OnRequestFinished, int id)
    {
        using (UnityWebRequest www = UnityWebRequest.Delete(string.Concat(PATH, id)))
        {
            yield return www.SendWebRequest();
            ResponseClient response = new ResponseClient();

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
