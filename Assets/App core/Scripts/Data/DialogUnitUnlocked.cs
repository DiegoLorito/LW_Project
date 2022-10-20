using System.Collections;
using System.Collections.Generic;
//using TMPro;

public class DialogUnitUnlocked : DialogCustom
{
    //[UnityEngine.HideInInspector]
    public UnitData dataUnit;

    public TMPro.TMP_Text unitName;
    public UnityEngine.UI.Text unitIndex;

    public UnityEngine.UI.Image unitBackground;
    public UnityEngine.UI.Image unitMiddleground;
    public UnityEngine.UI.Image unitMiddlegroundFill;
    public UnityEngine.UI.Image unitIcon;

    public UnityEngine.UI.Button button;

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public override void SetData()
    {
        unitName.text = dataUnit.core.Name;
        unitName.gameObject.SetActive(false);
        unitName.outlineColor = dataUnit.core.colorMiddleground;
        unitName.gameObject.SetActive(true);

        unitIndex.text = $"Unit {dataUnit.index}";
        unitIndex.color = dataUnit.core.colorMiddleground;  

        unitBackground.color = dataUnit.core.colorBackground;
        unitMiddleground.color = dataUnit.core.colorMiddleground;
        unitMiddlegroundFill.color = dataUnit.core.colorMiddleground;

        unitMiddleground.sprite = dataUnit.background;
        unitIcon.sprite = dataUnit.icon;
    }
    public void OnClick()
    {
        UserData dataUser = AppServerData.instance.dataCurrentUser;

        dataUser.codeCurUnit = dataUnit.core.code;

        ControladorData.instance.unitColor = dataUnit.core.colorMiddleground;
        ControladorData.instance.data.user.codeCurUnit = dataUnit.core.code;

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            TransitionController.instance.RoutineTransitionIn(),
            RoutinesController.Action(() => GameEvents.HideCustomDialog()),
            RoutinesController.Action(() => GameEvents.ChangeAppScreen(1)),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
}
