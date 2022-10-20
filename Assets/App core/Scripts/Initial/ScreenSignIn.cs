using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Nobi.UiRoundedCorners;
using System.Collections;
using System.Collections.Generic;

public class ScreenSignIn : AppScreen
{
    [Header("General")]
    public RectTransform canvas;
    public GameObject[] sections;
    public Image fade;
    public RectTransform column;
    public Button btnBack;

    [Space(10)]
    [Header("SignUp Input Data")]
    public InputFieldBasic[] inputs;

    private ImageWithIndependentRoundedCorners corners;
    private int currSection = 0;

    [Space(10)]
    [Header("Navigation")]
    public HeaderWithProgress progress;

    [Space(10)]
    [Header("Dialog")]
    public DialogData dataDialog;


    private void Awake()
    {
        GameEvents.onSignInError += SignInError;

        fade.gameObject.SetActive(false);
        corners = column.GetComponent<ImageWithIndependentRoundedCorners>();
    }
    public override void LoadContent()
    {
        InitScreen();
    }

    //==========================================================================
    public void SignIn(bool isPremiun)
    {
        BEClient client = new BEClient();
         
        client.str_client_name = inputs[0].input.text;
        client.str_client_lastname = inputs[1].input.text;
        client.str_client_email = inputs[2].input.text;
        client.str_client_password = inputs[3].input.text;
        client.bool_premiun_account = isPremiun;
        client.dte_start_free_trial = "1900-12-12";

        List<IEnumerator> routines = new List<IEnumerator>();

        routines.Add(TransitionController.instance.RoutineTransitionIn());
        routines.Add(DAClient.Create(CreateClient, client));
        routines.Add(RoutinesController.Action(()=> SaveClientDataOnJson()));
        routines.Add(RoutinesController.Action(()=> controller.ChangeAppScreen(3)));

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    private void SaveClientDataOnJson()
    {
        AppServerData.instance.dataClient.name = inputs[0].input.text;
        AppServerData.instance.dataClient.lastName = inputs[1].input.text; ;
        AppServerData.instance.dataClient.email = inputs[2].input.text;
        AppServerData.instance.dataClient.password = inputs[3].input.text;
        //AppServerData.instance.dataClient.premiun;

        ControladorData.instance.data = new AppJsonData();

        ControladorData.instance.data.client = AppServerData.instance.dataClient;
        ControladorData.instance.data.loggedIn = true;
        ControladorData.instance.SaveAppData();
    }
    private void SignInError(ErrorResponse error)
    {
        print("Error al crear cliente");
    }
    public void DialogCancel()
    {
        dataDialog.actionOne = () => GameEvents.HideDialog();
        dataDialog.actionTwo = () => GameEvents.HideDialog(() => controller.TransitionAppScreen(0));

        GameEvents.ShowDialog(dataDialog);
    } 

    //==========================================================================
    public void InitScreen()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].gameObject.SetActive(true);
            if (sections[i].TryGetComponent(out SignUpSection component))
            {
                component.Restart();
            }
            sections[i].gameObject.SetActive(false);
        }

        progress.SetIndicatorFocus(9);
        currSection = 0;
        column.DOAnchorMax(Vector2.one, 0);
        corners.r[0] = 100;
        corners.r[1] = 100;

        sections[0].gameObject.SetActive(true);
        progress.SetIndicatorFocus(0);
        fade.gameObject.SetActive(false);
    }
    public void NextSection()
    {
        GameEvents.CanvasInteractable(false);
        fade.gameObject.SetActive(true);

        switch (currSection)
        {
            case 0:

                Color colorGray = ConstantsUI.colorLightGray3;
                colorGray.a = 0.4f;

                btnBack.image.DOColor(colorGray, 0.25f);

                Sequence seq1 = DOTween.Sequence();

                seq1.Append(fade.DOFade(1, 0.5f))
                    .AppendCallback(() =>
                    {
                        StartCoroutine(DAClient.Find(FindClient, "str_client_email", inputs[2].input.text));
                    });

                break;

            case 1:

                btnBack.image.DOColor(ConstantsUI.colorPink1,0.25f);


                float newHeight = canvas.rect.height / column.parent.GetComponent<RectTransform>().rect.height;
                Sequence seq2 = DOTween.Sequence();

                seq2.Append(fade.DOFade(1, 0.5f))
                    .Append(column.DOAnchorMax(new Vector2(1,newHeight),0.5f))
                    .AppendCallback(() =>
                    {
                        ShowSection(2);
                    })
                    .Append(fade.DOFade(0, 0.5f))
                    .OnComplete(() =>
                    {
                        fade.gameObject.SetActive(false);
                        GameEvents.CanvasInteractable(true);
                    });

                seq2.Insert(0.5f, DOTween.To(() => corners.r.x, x => corners.r.x = x, 0, 0.5f));
                seq2.Insert(0.5f, DOTween.To(() => corners.r.x, x => corners.r.y = x, 0, 0.5f));

                currSection++;

                break;
            default:
                currSection++;
                break;
        }
        
    }
    public void BackSection()
    {
        if(currSection != 0) fade.gameObject.SetActive(true);

        switch (currSection)
        {
            case 0:
                DialogCancelRegister(dataDialog);
                return;

            case 1:

                GameEvents.CanvasInteractable(false);

                Sequence seq1 = DOTween.Sequence();

                seq1.Append(fade.DOFade(1, 0.5f))
                    .AppendCallback(() => ShowSection(0))
                    .Append(fade.DOFade(0, 0.5f))
                    .OnComplete(() =>
                    {
                        fade.gameObject.SetActive(false);
                        GameEvents.CanvasInteractable(true);
                    });

                break;
            case 2:

                float currHeigh = column.parent.GetComponent<RectTransform>().rect.height;

                Sequence seq2 = DOTween.Sequence();

                seq2.Append(fade.DOFade(1, 0.5f))
                    .Append(column.DOAnchorMax(Vector2.one, 0.5f))
                    .AppendCallback(()=> ShowSection(1))
                    .Append(fade.DOFade(0, 0.5f))
                    .OnComplete(() =>
                    {
                        fade.gameObject.SetActive(false);
                        GameEvents.CanvasInteractable(true);
                    });

                seq2.Insert(0.5f, DOTween.To(() => corners.r.x, x => corners.r.x = x, 100, 0.5f));
                seq2.Insert(0.5f, DOTween.To(() => corners.r.x, x => corners.r.y = x, 100, 0.5f));

                break;
            default:
                break;
        }

        Color colorGray = ConstantsUI.colorLightGray3;
        colorGray.a = 0.4f;

        btnBack.image.DOColor(colorGray, 0.25f);

        currSection--;
    }
    private void ShowSection(int index)
    {
        for (int i = 0; i < sections.Length; i++)
        {
            if (i == index)
            {
                sections[i].SetActive(true);
            }
            else
            {
                sections[i].SetActive(false);
            }
        }

        progress.SetIndicatorFocus(index);
    }

    public void CreateClient(ResponseClientID response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    GameEvents.SignInSuccessful(response);
                    break;
                case 204: //Response vacio pero si se hace la consulta

                    break;
                case 400: //Por error de parametro no se hace la consulta

                    break;

                default:
                    Debug.Log("Response code: " + response.statusCode);
                    break;
            }
        }
    }
    private void FindClient(ResponseClient response, ErrorResponse error)
    {
        if (response is null)
        {
            Utils.Log("red", "Error code: " + error.code + " Message: " + error.message, LogType.Error, true);
            DBCallbacks.ErrorResponse("404", "Connection error");
        }
        else
        {
            switch (response.statusCode)
            {
                case 200:
                    CheckClientEmailCompleted(delegate { GameEvents.ConectionError(null,true,"email", "Email is already registered, try Log in."); });
                    break;
                case 204: //Response vacio pero si se hace la consulta
                    CheckClientEmailCompleted(delegate { ShowSection(1); currSection++; });                    
                    break;
                case 400: //Por error de parametro no se hace la consulta
                    //CheckClientEmailCompleted(delegate { GameEvents.ShowErrorDialog("400", "Wrong parameter was passed."); });
                    break;

                default:
                    break;
            }
        }
    }
    private void CheckClientEmailCompleted(TweenCallback action)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(action)
            .Append(fade.DOFade(0, 0.5f))
            .OnComplete(() =>
            {
                fade.gameObject.SetActive(false);
                GameEvents.CanvasInteractable(true);
            });
    }
    private void DialogCancelRegister(DialogData dataDialog)
    {
        RoutinesController.error = false;

        dataDialog.actionOne = () => GameEvents.HideDialog();
        dataDialog.actionTwo = () => GameEvents.HideDialog(() => controller.TransitionAppScreen(0));

        GameEvents.ShowDialog(dataDialog);
    }
    private void OnDestroy()
    {
        GameEvents.onSignInError -= SignInError;
    }
}
