using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DAParentZoneReport
{
    public static string PATH = string.Concat(Constants.PATH_API, Constants.PATH_PZ_UNIT_REPORT);

    public static async Task Find(Action<ResponsePZUnitReport, ErrorResponse> OnRequestFinished, int id_user_account, int id_world)
    {
        Utils.PrintStartTime("DAParentZoneReport");
        string queryParams;

        if (id_user_account == 0 || id_world == 0)
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?id_user_account=" + id_user_account + "&id_world=" + id_world;
        }

        UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        ResponsePZUnitReport response = new ResponsePZUnitReport();

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
            response = JsonUtility.FromJson<ResponsePZUnitReport>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DAParentZoneReport");
    }
}
