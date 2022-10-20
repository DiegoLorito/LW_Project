using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class DAReportContent
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_REPORT_CONTENT);

    public static IEnumerator FindContentProgress(Action<ResponseReportContent, ErrorResponse> OnRequestFinished, int id_user_account = 0, int id_world = 0, string str_unit_code="")
    {
        string queryParams;

        if (id_user_account == 0 || id_world == 0 || str_unit_code.Equals(string.Empty))
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?id_user_account=" + id_user_account + "&id_world=" + id_world + "&str_unit_code=" + str_unit_code;
        }

        using (UnityWebRequest www = UnityWebRequest.Get(string.Concat(PATH, queryParams)))
        {
            yield return www.SendWebRequest();
            ResponseReportContent response = new ResponseReportContent();

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
                response = JsonUtility.FromJson<ResponseReportContent>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

}
