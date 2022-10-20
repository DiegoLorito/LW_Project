using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ControladorDialog : MonoBehaviour
{
    public Dialog normalDialog;

    public DialogData[] normalDialogs;
    // [0] Cancelar registro
    // [1] Cancelar Log out
    // [2] Unidad desbloqueada
    public DialogData[] errorDialogs;

    public DialogCustom[] customs;

    public GameObject container;
    public Image background;
    private int current;


    private void Awake()
    {
        GameEvents.onShowErrorDialog += ShowErrorDialog;
        GameEvents.onHideDialog += HideDialog;
        GameEvents.onShowDialog += Show;

        GameEvents.onShowCustomDialog += ShowCustomDialog;
    }
    private void Start()
    {
        container.SetActive(true);

        for (int i = 0; i < customs.Length; i++)
        {
            customs[i].controller = this;
            customs[i].Init();
            customs[i].gameObject.SetActive(false);
        }

        container.SetActive(false);
    }
    private void Show(DialogData data)
    {
        GameEvents.CanvasInteractable(false);

        background.DOFade(0, 0);
        container.SetActive(true);

        normalDialog.transform.localScale = Vector3.zero;
        normalDialog.data = data;
        normalDialog.gameObject.SetActive(true);
        normalDialog.SetData();

        Sequence seq = DOTween.Sequence();

        seq.Append(background.DOFade(0.5f, 0.25f))
            .Append(normalDialog.transform.DOScale(1, 0.25f).SetEase(Ease.OutBack))
            .OnComplete(()=> GameEvents.CanvasInteractable(true));
    }

    public void ShowErrorDialog(Action action = null,bool simple = false, string title = "", string description = "")
    {
        DialogData data = simple ? errorDialogs[0]:errorDialogs[1];

        if (title != "") data.title = title;
        if (description != "") data.description = description;

        data.actionOne = () => HideDialog(action);

        GameEvents.HideLoadingScreen();
        Show(data);
    }
    public void HideDialog(Action action = null)
    {
        GameEvents.CanvasInteractable(false);

        Sequence seq = DOTween.Sequence();

        seq.Append(normalDialog.transform.DOScale(0, 0.25f).SetEase(Ease.InBack))
            .Append(background.DOFade(0, 0.25f))
            .OnComplete(delegate
            {
                GameEvents.CanvasInteractable(true);
                normalDialog.gameObject.SetActive(false);
                container.SetActive(false);

                if (action != null) action();
            });
    }

    public void ShowCustomDialog(DialogCustom _dialog)
    {
        background.DOFade(0, 0);
        container.SetActive(true);

        _dialog.transform.localScale = Vector3.zero;
        _dialog.gameObject.SetActive(true);
        _dialog.SetData();

        GameEvents.CanvasInteractable(false);

        Sequence seq = DOTween.Sequence();

        seq.Append(background.DOFade(0.5f, 0.25f))
            .Append(_dialog.transform.DOScale(1, 0.25f).SetEase(Ease.OutBack))
            .OnComplete(() => GameEvents.CanvasInteractable(true));
    }
    public void HideCustomDialog(GameObject cDialog)
    {
        GameEvents.CanvasInteractable(false);

        Sequence seq = DOTween.Sequence();

        seq.Append(cDialog.transform.DOScale(0, 0.25f).SetEase(Ease.InBack))
            .Append(background.DOFade(0, 0.25f))
            .OnComplete(delegate
            {
                GameEvents.CanvasInteractable(true);
                cDialog.SetActive(false);
                container.SetActive(false);
            });
    }
    private void OnDestroy()
    {
        GameEvents.onShowErrorDialog -= ShowErrorDialog;
        GameEvents.onHideDialog -= HideDialog;
        GameEvents.onShowDialog -= Show;
        GameEvents.onShowCustomDialog -= ShowCustomDialog;
    }



} 
