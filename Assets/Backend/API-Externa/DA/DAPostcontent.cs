using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft;

public static class DAPostcontent
{
    private static string PATH = string.Concat(Constants.BLOG_API, Constants.PATH_BLOG_POSTS_CONTENT);

    public static async Task GetPostContent(Action<BEPostContent, ErrorResponse> OnRequestFinished, int id_post, string accessToken)
    {
        Utils.PrintStartTime("DAPostcontent");
        UnityWebRequest www = UnityWebRequest.Get(PATH + id_post);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer  " + accessToken);
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        Debug.Log(www.downloadHandler.text);

        BEPostContent response;

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
            response = JsonUtility.FromJson<BEPostContent>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DAPostcontent");
    }
}
