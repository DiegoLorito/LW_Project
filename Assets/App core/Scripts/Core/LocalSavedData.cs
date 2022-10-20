using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalSavedData
{
    //========== AVATAR ID ==========//
    public static void SetAvatarId(int data)
    {
        PlayerPrefs.SetInt("avatarId", data);
    }
    public static int GetAvatarId()
    {
        return PlayerPrefs.GetInt("avatarId");
    }

    //========== GAME COMPLETE ==========//
    public static void SetGameComplete(bool data)
    {
        int aux = data ? 1 : 0;
        PlayerPrefs.SetInt("gameCompleted", aux);
    }
    public static bool GetGameComplete()
    {
        bool aux = PlayerPrefs.GetInt("gameCompleted") == 0 ? false : true;
        return aux;
    }


    //========== CURRENT GAME ==========//
    public static void SaveCurrentGameId(int data)
    {
        PlayerPrefs.SetInt("currentGameID", data);
    }
    public static int LoadCurrentGameId()
    {
        return PlayerPrefs.GetInt("currentGameID");
    }

    //========== COME BACK FROM GAME ==========//
    public static void SetComeFromInteraction(bool data)
    {
        int vaue = data ? 1 : 0;
        PlayerPrefs.SetInt("comeFromGame", vaue);
    }
    public static bool GetComeFromInteraction()
    {
        bool value = PlayerPrefs.GetInt("comeFromGame") == 1 ? true : false;
        return value;
    }

    //========== CONTENT ID ==========//
    public static void SetContentId(int data)
    {
        PlayerPrefs.SetInt("contentId", data);
    }
    public static int GetContentId()
    {
        return PlayerPrefs.GetInt("contentId");
    }
}
