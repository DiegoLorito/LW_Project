using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorProgresoUnidadesMundo : MonoBehaviour
{
    private void UpdateProgressUnitWorld(int currentUnitIndex, int maxUnitIndex)
    {
        BEProgressUnitWorld _beProgressUnitWorld = new BEProgressUnitWorld();

        //_beProgressUnitWorld.id_world = AppServerData.instance.GetCurrentWorld().id;
        //_beProgressUnitWorld.id_user_account = AppServerData.instance.dataCurrentUser.idAccount;
        //_beProgressUnitWorld.int_current_unit_index = currentUnitIndex;
        //_beProgressUnitWorld.int_max_unit_index_unlocked = maxUnitIndex;


        StartCoroutine(DAProgressUnitWorld.Update(DBCallbacks.UpdateProgressUnitWorld, _beProgressUnitWorld));
    }
    private void ProgressUnitWorldUpdated(ResponseProgressUnitWorld response, Action action)
    {
        //GameEvents.FindContent(response.data[0].int_current_unit_index);
        if (action != null) action();
    }
    private void ProgressUnitWorldNotUpdated(ErrorResponse error)
    {

    }
}
