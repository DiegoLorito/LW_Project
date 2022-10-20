using UnityEngine;
using DG.Tweening;

public class ControladorPIN : MonoBehaviour
{
    private int currentView;
    private string pin;

    public string sceneParentName = "App Loritos World";

    public UnityEngine.UI.Text[] inputViews;

    [Header("Content")]
    public UnityEngine.UI.Image background;
    public UnityEngine.UI.Image stateIcon;
    public RectTransform panel;

    [Header("Sprites")]
    public Sprite[] stateIcons;

    private void Awake()
    {
        GameEvents.onShowSecurityPin += ShowPanel;
    }
    private void OnDisable()
    {
        GameEvents.onShowSecurityPin -= ShowPanel;
    }

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        currentView = 0;

        for (int i = 0; i < inputViews.Length; i++)
        {
            inputViews[i].text = "";
        }

        stateIcon.sprite = stateIcons[0];
    }
    public void InputDigit(string value)
    {
        inputViews[currentView].text = value;
        currentView++;

        if(currentView == inputViews.Length)
        {
            GameEvents.CanvasInteractable(false);
            ValidatePIN();
        }
    }
    private void ValidatePIN()
    {
        pin = "";

        for (int i = 0; i < inputViews.Length; i++)
        {
            pin += inputViews[i].text;
        }

        int pinValue = int.Parse(pin);
        int pinValidation = System.DateTime.Now.Year - pinValue;

        if (pinValidation > 17 && pinValidation < 100)
        {
            stateIcon.sprite = stateIcons[1];
            DOVirtual.DelayedCall(0.5f, () => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneParentName));
        }
        else
        {
            stateIcon.sprite = stateIcons[2];
            stateIcon.GetComponent<RectTransform>().DOShakeAnchorPos(1,10,10,90,true,true).OnComplete(()=> HidePanel());

            //DOTween.Shake(stateIcon.transform,)
        }
    } 
    public void ShowPanel()
    {
        GameEvents.CanvasInteractable(false);

        Init();

        background.color.SetAlpha(0);
        background.gameObject.Enable();

        panel.gameObject.Enable();
        panel.DOAnchorPosY(-1080,0);


        background.DOFade(0.5f, 0.5f);
        panel.DOAnchorPosY(0, 0.5f).OnComplete(()=> GameEvents.CanvasInteractable(true));
    }
    public void HidePanel()
    {
        GameEvents.CanvasInteractable(false);

        background.DOFade(0, 0.5f);
        panel.DOAnchorPosY(-1080, 0.5f).OnComplete(()=>
        {
            background.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            GameEvents.CanvasInteractable(true);
        });
    }
   
}
