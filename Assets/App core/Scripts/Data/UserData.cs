using UnityEngine;

[System.Serializable]
public class UserData
{
    [Space(10)]
    [Header("USER DATA")]
    public int id;
    public int idAccount;
    public string name;
    public System.DateTime birthDate;

    [Space(10)]
    public int worldId;
    public string codeCurUnit;
    public string codeMaxUnit; 
    public string avatarCode;

    public int indexCurUnit;
    public int indexMaxUnit;

     public SO_WorldCore _world;
     public SO_UnitCore _currentUnit;
     public SO_UnitCore _maximunUnit;

     public SO_Avatar _avatar;

    [Space(10)]
    [Header("COIN DATA")]
    public int coins;

    //=== CONSTRUCTORES ===//
    #region CONSTRUCTORES
    public UserData(UserData data = null)
    {
        if (data == null) return;

        this.id = data.id;
        this.name = data.name;
        this.idAccount = data.idAccount;
        this.worldId = data.worldId;

        this.codeCurUnit = data.codeCurUnit;
        this.codeMaxUnit = data.codeMaxUnit;
        this.indexCurUnit = data.indexCurUnit;
        this.indexMaxUnit = data.indexMaxUnit;

        this._world = data._world;
        this._currentUnit = data.CurrentUnit;
        this._maximunUnit = data.MaximunUnit;

        this.coins = data.coins;
        this.avatarCode = data.avatarCode;
        this._avatar = data.Avatar;
    }
    public UserData(BEReportUser data)
    {
        if (data == null) return;

        this.id = data.id_user;
        this.name = data.str_user_name;
        //this.birthDate = data.
        this.idAccount = data.id_user_account;
        this.worldId = data.int_current_id_world;

        this.codeCurUnit = data.str_current_unit_code;
        this.codeMaxUnit = data.str_max_unit_code_unlocked;
        this.avatarCode = data.str_current_avatar_code;
        this.coins = data.int_user_account_coins;

        //this.curUnit = this._world.GetUnit(this.codeCurUnit);
        //this.maxUnit = this.world.GetUnit(this.codeMaxUnit);
        //this.indexCurUnit = CurrentUnit.index;
        //this.indexMaxUnit = _maximunUnit.index;

        this._avatar = LocalData.Instance.GetDataAvatar(avatarCode);
    }

    #endregion


    public SO_UnitCore CurrentUnit
    {
        get
        {
            if (!_currentUnit)
            {
                _currentUnit = DataUnitCore.Instance.Data[codeCurUnit];

                if (_currentUnit == null) _currentUnit = UnitsData.instance.dataUnitsCore[0];
            }

            return _currentUnit;
        }
        set
        {
            _currentUnit = value;
        }
    }
    public SO_UnitCore MaximunUnit
    {
        get
        {
            if (!_maximunUnit)
            {
                _maximunUnit = DataUnitCore.Instance.Data[codeCurUnit];

                if (_maximunUnit == null) _maximunUnit = UnitsData.instance.dataUnitsCore[0];
            }

            return _maximunUnit;
        }
        set
        {
            _maximunUnit = value;
        }
    }
    public SO_Avatar Avatar
    {
        get
        {
            if (!_avatar)
            {
                _avatar = LocalData.Instance.GetDataAvatar(avatarCode);

                //if (!_avatar) _avatar = CatalogAvatars.instance.data[0];
            }

            return _avatar;
        }
        set
        {
            _avatar = value;
        }
    }

    public int UnitIndex(string code)
    {
        //return CatalogWorlds.instance.GetWorldById(worldId).units.FindIndex(x => x.core.code == code);
        return 0;
    }
    public void Update(UserData data)
    {
        this.id = data.id;
        this.name = data.name;
        this.idAccount = data.idAccount;
        this.worldId = data.worldId;

        this.codeCurUnit = data.codeCurUnit;
        this.codeMaxUnit = data.codeMaxUnit;
        this.indexCurUnit = data.indexCurUnit;
        this.indexMaxUnit = data.indexMaxUnit;

        this.coins = data.coins;
        this.avatarCode = data.avatarCode;
        this._avatar = data.Avatar;
    }
    public void Restart()
    {
        //this.codeCurUnit = _world.units[0].core.code;
        //this.codeMaxUnit = _world.units[0].core.code;
        //this.curUnit = _world.units[0];
        //this.maxUnit = _world.units[0];
        //this.indexCurUnit = _world.units[0].index;
        //this.indexMaxUnit = _world.units[0].index;
    }
}
