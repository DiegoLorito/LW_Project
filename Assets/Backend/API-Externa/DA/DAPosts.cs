using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft;
using UnityRest;

public static class DAPosts 
{
    private static string PATH = string.Concat(Constants.BLOG_API, Constants.PATH_BLOG_POSTS);

    public static async Task GetAll(Action<BEPosts[], ErrorResponse> OnRequestFinished, int page,string accessToken)
    {
        Utils.PrintStartTime("DAPosts");
        string queryParams;

        if (page <= 0)
        {
            queryParams = null;
        }
        else
        {
            queryParams = "?paged" + "=" + page;
        }

        UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer  " + accessToken);
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        //Debug.Log(www.downloadHandler.text);

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            OnRequestFinished.Invoke(null, new ErrorResponse(0, www.error));
        }
        else if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.downloadHandler.text);
            BEErrorBlog errorResponse = new BEErrorBlog();
            errorResponse = JsonUtility.FromJson<BEErrorBlog>(www.downloadHandler.text);
            OnRequestFinished.Invoke(null, new ErrorResponse(Convert.ToInt32(www.responseCode), errorResponse.code));
        }
        else
        {
            BEPosts[] bePost = JsonHelper.FromJson<BEPosts>(www.downloadHandler.text);
            OnRequestFinished.Invoke(bePost, null);
        }
        Utils.PrintEndTime("DAPosts");
    }
}
