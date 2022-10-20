using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorUsuarioCuenta : MonoBehaviour
{
    private void Awake()
    {
        GameEvents.onFindUserAccount += FindUserAccount;
        GameEvents.onUserAccountFound += UserAccountFound;
        GameEvents.onUserAccountNotFound += UserAccountNotFound;
    }
    private void FindUserAccount(int userId)
    {
        //DAUserAccount _dAUserAccount = new DAUserAccount();
        //StartCoroutine(_dAUserAccount.Find(DBCallbacks.FindUserAccount, "id_user", userId.ToString()));
    }
    private void UserAccountFound(ResponseUserAccount response)
    {
        ControladorData.instance.data.user.id = response.data[0].id_user;
        ControladorData.instance.data.user.idAccount = response.data[0].id_user_account;
        ControladorData.instance.data.user.coins = response.data[0].int_user_account_coins;
        ControladorData.instance.SaveAppData();

        //GameEvents.UpdateCoins(response.data[0].int_user_account_coins);
        //GameEvents.FindUnits(ControladorData.instance.data.user.worldId);
    }
    private void UserAccountNotFound(ErrorResponse error)
    {
        print("USER ACCOUNT NOT FOUND, ERROR: " + error.code);
    }
    private void OnDestroy()
    {
        GameEvents.onFindUserAccount -= FindUserAccount;
        GameEvents.onUserAccountFound -= UserAccountFound;
        GameEvents.onUserAccountNotFound -= UserAccountNotFound;
    }
}
