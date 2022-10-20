using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class DAReportUser
{
    private static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_REPORT_USER);

    public static IEnumerator FindUsersProgress(Action<ResponseReportUser, ErrorResponse> OnRequestFinished, int id_client)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(string.Concat(PATH, id_client)))
        {
            yield return www.SendWebRequest();
            ResponseReportUser response = new ResponseReportUser();

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
                response = JsonUtility.FromJson<ResponseReportUser>(www.downloadHandler.text);
                OnRequestFinished.Invoke(response, null);
            }
        }
    }

}
