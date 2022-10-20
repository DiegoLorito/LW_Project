using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
public class DALikePost
{
    private static string PATH = string.Concat(Constants.BLOG_API, Constants.PATH_LIKE_POSTS);

    public static async Task Like(Action<BELikePost, ErrorResponse> OnRequestFinished, int id_post, string accessToken)
    {
        Utils.PrintStartTime("DALikePost");
        string queryParams;

        if (id_post <= 0)
        {
            queryParams = null;
        }
        else
        {
            queryParams = id_post + "/liked" ;
        }

        UnityWebRequest www = UnityWebRequest.Get(PATH + queryParams);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer  " + accessToken);
        www.SendWebRequest();

        while (!www.isDone)
            await Task.Yield();

        Debug.Log(www.downloadHandler.text);

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
            BELikePost response = JsonUtility.FromJson<BELikePost>(www.downloadHandler.text);
            OnRequestFinished.Invoke(response, null);
        }
        Utils.PrintEndTime("DALikePost");
    }
}
