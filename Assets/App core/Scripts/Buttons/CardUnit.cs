using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UnitStatus { Locked, InProgress, Completed }

public class CardUnit : MonoBehaviour
{
    [HideInInspector] public HubUnits screen;
    [HideInInspector] public bool current;

    public UnitStatus status;

    public SO_UnitCore unitData;

    public TextMeshProUGUI txtNombre;
    public Text txtNumero;

    public Image border;
    public Image card;
    public UnitIcon icon;
    public Button boton;

    public GameObject iconLock;

    private bool progressUnitUpdated;

    public void SetButton()
    {
        Color _clBackground = unitData.colorBackground;
        Color _clMiddleground = unitData.colorMiddleground;

        txtNombre.text = unitData.Name;
        txtNumero.text = "Unit " + unitData.index;

        icon.icon.sprite = unitData.icon;
        icon.background.sprite = unitData.background;
        icon.fill.color = _clMiddleground;

        switch (status)
        {
            case UnitStatus.Locked:
                icon.SetActive(false);
                iconLock.SetActive(true);
                card.color = ConstantsUI.colorLightGray;
                txtNombre.enableVertexGradient = false;
                txtNombre.color = ConstantsUI.colorGray;
                txtNumero.color = ConstantsUI.colorGray;

                boton.interactable = false;
                break;
            default:
                icon.SetActive(true);
                iconLock.SetActive(false);
                card.color = _clBackground;
                icon.ChangeColor(_clMiddleground);
                txtNombre.color = Color.white;
                txtNombre.enableVertexGradient = true;
                txtNumero.color = _clMiddleground;

                boton.interactable = true;
                break;
        }


        //Activamos el borde si esta seleccionado
        SetActiveBorder(current);

        //background.sprite = _background;
        boton.onClick.RemoveAllListeners();
        boton.onClick.AddListener(delegate { OnClick(); });
    }

    private void OnClick()
    {
        current = true;

        //UnitsData.instance.CurrentUnit = unitData;

        AppServerData.instance.dataCurrentUser.CurrentUnit = unitData;
        AppServerData.instance.dataCurrentUser.codeCurUnit = unitData.code;

        ControladorData.instance.unitColor = unitData.colorMiddleground;
        ControladorData.instance.data.user.CurrentUnit  = unitData;
        ControladorData.instance.data.user.codeCurUnit = unitData.code;

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            TransitionController.instance.RoutineTransitionIn(),
            RoutinesController.Action(() => screen.controller.ChangeAppScreen(1)),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }

    private void SetActiveBorder(bool value)
    {
        //Activamos el borde si esta seleccionado
        Color _color = Color.white;

        if (value) _color.a = 1;
        else _color.a = 0;

        border.color = _color;
    }

    public IEnumerator UpdateProgressUnitWorld(int currentUnitIndex, int maxUnitIndex)
    {
        UserData dataUser = AppServerData.instance.dataCurrentUser;

        BEProgressUnitWorld _beProgressUnitWorld = new BEProgressUnitWorld();

        //_beProgressUnitWorld.id_world = dataUser.world.id;
        //_beProgressUnitWorld.id_user_account = dataUser.idAccount;
        //_beProgressUnitWorld.int_current_unit_index = currentUnitIndex;
        //_beProgressUnitWorld.int_max_unit_index_unlocked = maxUnitIndex;

        yield return DAProgressUnitWorld.Update(DBCallbacks.UpdateProgressUnitWorld, _beProgressUnitWorld);
    }



}

[System.Serializable]
public class UnitIcon
{
    public Image icon;
    public Image background;
    public Image fill;

    public void SetActive(bool value)
    {
        icon.gameObject.SetActive(value);
        fill.gameObject.SetActive(value);
        background.gameObject.SetActive(value);
    }
    public void ChangeColor(Color color)
    {
        background.color = color;
        fill.color = color;
    }
}
