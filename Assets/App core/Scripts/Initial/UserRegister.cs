using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UserRegister : AppScreen
{
    [Header("General")]
    public RectTransform canvas;
    public UserRegisterSection[] sections;
    public Image fade;

    [Header("SignUp Input Data")]
    public InputBasic[] inputs;
    // [0] Name
    // [1] Avatar
    // [2] Day
    // [3] Month
    // [4] Year
    // [5] World

    [Header("Navigation")]
    public Text header;
    public HeaderWithProgress progress;

    [Header("Dialog Data")]
    public DialogData dataDialog;

    [Space(10)]
    [HideInInspector]public int currSection = 0;

    public override void LoadContent()
    {
        InitScreen();
        ContentLoaded();
        ContentSetted();
    }
    public void CreateUser()
    {
        string day = (inputs[2] as InputFieldBasic).input.text;
        string month = (inputs[3] as InputFieldBasic).input.text;
        string year = (inputs[4] as InputFieldBasic).input.text;

        if (day.Length == 1) day = $"0{day}";
        if (month.Length == 1) month = $"0{month}";

        string date = day + "-" + month + "-" + year;
        string initUnit = inputs[5].intValue == 1 ? "UP-1" : "UM-1";

        BEUser beUser = new BEUser();

        beUser.dte_birth_date = date;
        beUser.str_user_name = inputs[0].stringValue;
        beUser.id_client = AppServerData.instance.dataClient.id;

        UserData dataUser = new UserData();

        dataUser.name = beUser.str_user_name;
        dataUser.birthDate = System.DateTime.ParseExact(date, "dd-MM-yyyy", null);
        dataUser.worldId = inputs[5].intValue;
        dataUser.codeCurUnit = initUnit;
        dataUser.codeMaxUnit = initUnit;
        dataUser.avatarCode = inputs[1].stringValue;
        dataUser.indexCurUnit = 1;
        dataUser.indexMaxUnit = 1; 
        dataUser.coins = 0;

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            TransitionController.instance.RoutineTransitionIn(),
            DAUser.Create(CreateUserCallback, beUser, dataUser.worldId, dataUser.codeCurUnit, dataUser.avatarCode, dataUser.codeCurUnit),
            RoutinesController.Action(() => controller.ChangeAppScreen(3)),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));

        void CreateUserCallback(ResponseUserCreated response, ErrorResponse error)
        {
            if (response is null)
            {
                Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
                GameEvents.ConectionError(CreateUser);
            }
            else
            {
                switch (response.statusCode)
                {
                    case 200:

                        dataUser.id = response.id_user;
                        dataUser.idAccount = response.id_user_account;

                        GameEvents.CreateUser(dataUser);
                        break;
                    case 204:
                        GameEvents.ConectionError(CreateUser);
                        break;
                    case 400:
                        GameEvents.ConectionError(CreateUser);
                        break;
                    default:
                        GameEvents.ConectionError(CreateUser);
                        break;
                }
            }
        }
    }

    public void DialogCancelRegister(DialogData dataDialog)
    {
        dataDialog.actionOne = () => GameEvents.HideDialog();
        dataDialog.actionTwo = () => GameEvents.HideDialog(() => controller.TransitionAppScreen(3));

        GameEvents.ShowDialog(dataDialog);
    }

    //==========================================================================
    public void NextSection()
    {
        GameEvents.CanvasInteractable(false);
        fade.gameObject.SetActive(true);
        currSection++;

        Sequence seq1 = DOTween.Sequence();

        seq1.Append(fade.DOFade(1, 0.5f))
            .AppendCallback(() => ShowSection(currSection))
            .Append(fade.DOFade(0, 0.5f))
            .OnComplete(() =>
            {
                fade.gameObject.SetActive(false);
                GameEvents.CanvasInteractable(true);
            });
    }
    public void BackSection()
    {
        if (currSection != 0) fade.gameObject.SetActive(true);

        switch (currSection)
        {
            case 0:
                DialogCancelRegister(dataDialog);
                return;

            default:

                GameEvents.CanvasInteractable(false);

                Sequence seq1 = DOTween.Sequence();

                seq1.Append(fade.DOFade(1, 0.5f))
                    .AppendCallback(() => ShowSection(currSection))
                    .Append(fade.DOFade(0, 0.5f))
                    .OnComplete(() =>
                    {
                        fade.gameObject.SetActive(false);
                        GameEvents.CanvasInteractable(true);
                    });

                currSection--;

                break;
        }

        
    }
    private void ShowSection(int index)
    {
        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].gameObject.SetActive(false);

            if (i == index)
            {
                sections[i].gameObject.SetActive(true);
                header.text = sections[i].header;
            }
        }

        progress.SetIndicatorFocus(index);
        
    }
    public void InitScreen()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        currSection = 0;

        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].gameObject.SetActive(true);
            if(sections[i].TryGetComponent(out UserRegisterSection component))
            {
                component.Restart();
            }
            sections[i].gameObject.SetActive(false);
        }
        progress.SetIndicatorFocus(9);
        sections[0].gameObject.SetActive(true);
        fade.gameObject.SetActive(false);
    }
}
