using UnityEngine;

public class Constants
{
    #region Endpoint Paths

   
    public const string PATH_STORE_ITEM_CATEGORY = "store-item-category/";

    public const string PATH_CLIENT = "client/";
    public const string PATH_LAST_CONTENT_ACTIVITY = "pz_last_content_activity/";
    public const string PATH_LAST_REWARDS = "pz_last_rewards/";
    public const string PATH_AUTHENTICATION = "authentication/";
    public const string PATH_PROGRESS = "progress/";
    public const string PATH_PROGRESS_UNIT_WORLD = "progress_unit_world/";
    public const string PATH_PROGRESS_USER_ACCOUNT = "progress_user_account/";
    public const string PATH_PURCHASED_LAND_ITEMS = "purchased_land_items/";
    public const string PATH_REPORT_CONTENT = "report_content/";
    public const string PATH_REPORT_USER = "report_user/";
    public const string PATH_REWARDS_COLLECTED = "rewards_collected/";
    public const string PATH_UNLOCKED_LAND = "unlocked_land/";
    public const string PATH_USER = "user/";
    public const string PATH_USER_ACCOUNT = "user_account/";
    public const string PATH_APP_STATUS = "app_status/";


    public const string PATH_REPORT_UNIT    = "report_unit/";
    public const string PATH_PZ_UNIT_REPORT = "blog_unit_report/";
    public const string PATH_CONTENT_PER_UNIT = "pz_content_per_unit/";
    public const string PATH_PROGRESS_PER_TYPE = "pz_progress_per_type/";
    public const string PATH_AVATAR_LAND_ITEMS = "purchased_avatar_items/";



    public const string PATH_BLOG_LOGIN = "jwt-auth/v1/token";
    public const string PATH_BLOG_POSTS = "ludik/v1/posts/";
    public const string PATH_LIKE_POSTS = "ludik/v1/posts/";
    public const string PATH_BLOG_REGISTER = "ludik/v1/users/register";
    public const string PATH_BLOG_POSTS_CONTENT = "ludik/v1/posts/";

    #endregion

    #region App Build

    public static string PATH_API = URL_DEV;
    public const string BLOG_API = "https://www.loritosworld.ludik.pe/wp-json/";

    #endregion

    #region Environment urls

    public const string URL_DEV = "https://dnnxzutlig.execute-api.us-east-2.amazonaws.com/dev/";
   // public const string URL_TEST = "https://911fm7110f.execute-api.us-east-2.amazonaws.com/testing/";

    public const string URL_PROD = "";

    #endregion

}
