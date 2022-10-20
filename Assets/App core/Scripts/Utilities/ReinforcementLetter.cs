using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class ReinforcementLetter : MonoBehaviour
{
    public Image imgBackground;
    public Image imgReinforcement;
    public Text txtReinforcement;

    [Space(5)]
    [SerializeField] private Color colorA;
    [SerializeField] private Color colorB;

    public RectTransform container;

    [Header("Audio")]
    private AudioSource source;
    private AudioClip clip;

    [Header("VFX")]
    [SerializeField] private SpriteRenderer lights;
    [HideInInspector] public bool ignoreTimeScale;

    private Sequence seqLighRotation;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        container.transform.localScale = Vector3.zero;
        imgBackground.gameObject.Disable();

        SetCanvasWorldCamerA();
        FitCanvasScaler();

        void FitCanvasScaler()
        {
            CanvasScaler scaler = GetComponent<CanvasScaler>();

            if (Screen.width / 2 < Screen.width)
            {
                scaler.matchWidthOrHeight = Helper.IsIpadScreen ? 0 : 1;
            }
            else
            {
                scaler.matchWidthOrHeight = Helper.IsIpadScreen ? 1 : 0;
            }
        }
        void SetCanvasWorldCamerA()
        {
            Canvas canvas = GetComponent<Canvas>();

            if (canvas.worldCamera == null) canvas.worldCamera = Helper.Camera;
        }
    }

    private void Reinforcement_In()
    {
        imgBackground.gameObject.Enable();
        imgBackground.SetAlpha(0);

        imgBackground.DOFade(0.65f, 0.25f);
        container.transform.DOScale(1, 0.5f)
            .OnComplete(PlayVocab)
            .SetEase(Ease.OutBack)
            .SetUpdate(ignoreTimeScale);

        LightRotaion();

        void PlayVocab()
        {
            source.clip = clip;
            source.Play();
        }

        void LightRotaion()
        {
            seqLighRotation = DOTween.Sequence();

            seqLighRotation
                .Append(lights.transform.DORotate(Vector3.forward * 360, 15, RotateMode.LocalAxisAdd).SetEase(Ease.Linear))
                .SetLoops(-1)
                .SetUpdate(ignoreTimeScale);
        }
    }
    public void Reinforcement_Out()
    {
        imgBackground.DOFade(0, 0.25f).OnComplete(imgBackground.gameObject.Disable);
        container.transform.DOScale(0, 0.5f);
    }

    public void ShowReinforcement(Sprite spReinforcement, string strReinforcement, AudioClip clip)
    {
        string hexValueA = ColorUtility.ToHtmlStringRGBA(colorA);
        string hexValueB = ColorUtility.ToHtmlStringRGBA(colorB);

        string firstChar = strReinforcement[0].ToString();
        string leftChars = strReinforcement.Substring(1);

        firstChar = $"<color=#{hexValueA}><b>{firstChar}</b></color>";
        leftChars = $"<color=#{hexValueB}>{leftChars}</color>";

        this.clip = clip;
        txtReinforcement.text = firstChar + leftChars;
        imgReinforcement.sprite = spReinforcement;

        Reinforcement_In();
    }
}
