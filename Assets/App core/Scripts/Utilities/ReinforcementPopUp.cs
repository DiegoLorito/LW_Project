using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class ReinforcementPopUp : MonoBehaviour
{
    [Header("Vocab Reinforcement")]
    [SerializeField] private Text _vocabWord;
    [SerializeField] private Image _vocabIcon;

    [Header("General")]
    [SerializeField] private float _duration;
    [SerializeField] private RectTransform _reinforcementContainer;
    [SerializeField] private CanvasGroup _groupContainer;
    [SerializeField] private CanvasGroup _groupBannerVocab;
    [SerializeField] private Image _background;
    [SerializeField] private Image _bannerVocab;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private bool _ignoreTimeScale;
    [HideInInspector] public UnityEvent onComplete;

    public bool isHorizontal;

    [Header("Character")]
    [SerializeField] private Transform _characterFinalPos;
    [SerializeField] private Transform _character;
    [SerializeField] private Animator _characterAnimator;

    private Vector3 _characterInitPos;
    private float _distanceOffScreen;

    [Header("Audio")]
    [SerializeField] private AudioSource _sourceVocab;
    [SerializeField] private AudioClip _clipCelebration;

    private AudioClip _clipVocab;

    [Header("VFX")]
    [SerializeField] private Color textColorPrincipal;
    [SerializeField] private Color textColorSecondary;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private SpriteRenderer _lights;
    [SerializeField] private ParticleSystem _partStarsBottom;
    [SerializeField] private ParticleSystem _parShine;
    [SerializeField] private ParticleSystem _parConfetti;

    private Sequence _seqLighRotation;
    

    private void Awake()
    {
        CanvasScaler scaler = GetComponent<CanvasScaler>();

        FitCanvasScaler();

        if (_canvas.worldCamera == null) _canvas.worldCamera = Helper.Camera;

        _character.gameObject.Disable();

        _distanceOffScreen = transform.position.y - _character.position.y;

        _characterAnimator.updateMode = _ignoreTimeScale ? AnimatorUpdateMode.UnscaledTime : AnimatorUpdateMode.Normal;
        //_groupContainer.alpha = 0;
        _groupContainer.transform.localScale = Vector3.zero;

        void FitCanvasScaler()
        {
            if(Screen.width/2 < Screen.width)
            {
                scaler.matchWidthOrHeight = Helper.IsIpadScreen ? 0 : 1;
            }
            else
            {
                scaler.matchWidthOrHeight = Helper.IsIpadScreen ? 1 : 0;
            }
        }
    }

    private void Reinforcement(bool withText, bool character)
    {
        float duration = _clipVocab.length + _duration;

        if (isHorizontal)
        {
            SetHoritontal();
        }
        else
        {
            SetNormal();
        }

        _bannerVocab.rectTransform.sizeDelta = new Vector2(120,120);

        _lights.SetAlpha(1);
        _groupContainer.transform.localScale = Vector3.zero;
        _groupContainer.transform.SetPosZ(0);
        _groupBannerVocab.alpha = 1;
        _groupContainer.alpha = 1;
        _background.SetAlpha(0); 
        _vocabWord.SetAlpha(0);
        _bannerVocab.SetAlpha(0);

        _background.gameObject.Enable();
        _groupContainer.gameObject.Enable();

        _background.DOFade(0.5f, 0.25f).SetUpdate(_ignoreTimeScale);

                                    
        LightRotaion();             // VFX de rotacion de luz
        _partStarsBottom.Play();    // VFX particulas desde parte inferior
        _parShine.Play();           // VFX particulas de brillo
        _parConfetti.Play();        // VFX particulas de confetti

        // Si el refuerzo tiene texto mostramos el pop up con texto
        if (withText)
        {
            ReinforcementWithText();
        }
        // Si el refuerzo no tiene texto mostramos el pop up con texto
        else
        {
            ReinforcementWithoutText();
        }

        //=== Método de refuerzo con texto
        void ReinforcementWithText()
        {
            // Si tiene personaje, mostramos el personaje
            if (character) ShowCharacter(0.75f);

            Sequence seqReinforcement = DOTween.Sequence();

            seqReinforcement
                .Append(_groupContainer.transform.DOScale(1, 0.35f).SetEase(Ease.OutBack))
                .Append(_bannerVocab.DOFade(1, 0.25f))
                .Append(_bannerVocab.rectTransform.DOSizeDelta(new Vector2(800, 120), 0.5f))
                .Append(_vocabWord.DOFade(1, 0.25f))
                .AppendCallback(PlayVocab)
                .AppendInterval(duration)
                .AppendCallback(HideReinforcement)
                .SetUpdate(_ignoreTimeScale);

            //=== Método de ocultar refuerzo
            void HideReinforcement()
            {
                if (character) HideCharacter();

                _lights.DOFade(0,0.1f).SetUpdate(_ignoreTimeScale);
                _parShine.Clear();
                _parShine.Stop(true);

                Sequence seqHideReinforcement = DOTween.Sequence();

                seqHideReinforcement
                    .Append(_groupBannerVocab.DOFade(0, 0.25f))
                    .Append(_groupContainer.DOFade(0, 0.25f))
                    .Append(_background.DOFade(0, 0.25f))
                    .AppendCallback(OnComplete)
                    .SetUpdate(_ignoreTimeScale);

                // Si existe una evento al completarse, lo llamamos
                void OnComplete()
                {
                    _seqLighRotation.Kill();
                    onComplete?.Invoke();
                }
            }
        }
        //=== Método de refuerzo sin texto
        void ReinforcementWithoutText()
        {
            // Si tiene personaje, mostramos el personaje
            if (character) ShowCharacter(0.15f);

            _reinforcementContainer.DOAnchorPosY(0, 0);

            Sequence seqReinforcement = DOTween.Sequence();

            seqReinforcement
                .Append(_groupContainer.transform.DOScale(1, 0.35f).SetEase(Ease.OutBack))
                .AppendInterval(0.5f)
                .AppendCallback(PlayVocab)
                .AppendInterval(duration)
                .AppendCallback(HideReinforcement)
                .SetUpdate(_ignoreTimeScale);

            //=== Método de ocultar refuerzo
            void HideReinforcement()
            {
                if (character) HideCharacter();

                _lights.DOFade(0, 0.1f).SetUpdate(_ignoreTimeScale);
                _parShine.Clear();
                _parShine.Stop(true);

                Sequence seqHideReinforcement = DOTween.Sequence();

                seqHideReinforcement
                    .Append(_groupContainer.DOFade(0, 0.25f))
                    .Append(_background.DOFade(0f, 0.25f))
                    .AppendCallback(OnComplete)
                    .SetUpdate(_ignoreTimeScale);

                // Si existe una evento al completarse, lo llamamos
                void OnComplete()
                {
                    _seqLighRotation.Kill();
                    onComplete?.Invoke();
                }
            }
        }

        //=== Método de mostrar al personaje
        void ShowCharacter(float delayToTalk = 0)
        {
            float currtentFinalPos = _characterFinalPos.position.x;

            if (isHorizontal) currtentFinalPos -= 1;

            _characterInitPos = new Vector3(currtentFinalPos, transform.position.y - _distanceOffScreen);
            Vector3 endPosition = new Vector3(currtentFinalPos, _characterFinalPos.position.y);

            _character.position = _characterInitPos;
            _character.gameObject.Enable();

            Sequence seqCharacter = DOTween.Sequence();

            seqCharacter
                .Append(_character.DOMove(endPosition, 0.5f))
                .AppendInterval(delayToTalk) // Tiempo de espera para hable al mismo tiempo que suena el vocab
                .OnComplete(OnComplete)
                .SetUpdate(_ignoreTimeScale);

            //=== Método para inicial la animacion de hablar del personaje
            void OnComplete()
            {
                _characterAnimator.SetTrigger("Talk");

                StopTalkAnimation();
            }
            //=== Método para detener la animacion de hablar
            void StopTalkAnimation()
            {
                float duration = _clipVocab.length + 0.75f;
                DOVirtual.DelayedCall(duration, StopAnimation);

                void StopAnimation()
                {
                    _characterAnimator.Rebind();
                    _characterAnimator.SetTrigger("Idle");
                }
            }
        }
        //=== Método de ocultar al personaje
        void HideCharacter()
        {
            float currtentFinalPos = _characterFinalPos.position.x;

            if (isHorizontal) currtentFinalPos -= 1;

            _characterInitPos = new Vector3(currtentFinalPos, transform.position.y - _distanceOffScreen);

            _character
                .DOMove(_characterInitPos, 0.5f)
                .OnComplete(_character.gameObject.Disable)
                .SetUpdate(_ignoreTimeScale);
        }

        //=== Método de reproducir la palabra de vocabulario
        void PlayVocab()
        {
            _sourceVocab.clip = _clipVocab;
            _sourceVocab.Play();
        }

        void LightRotaion()
        {
            _seqLighRotation = DOTween.Sequence();

            _seqLighRotation
                .Append(_lights.transform.DORotate(Vector3.forward * 360, _rotationDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear))
                .SetLoops(-1)
                .SetUpdate(_ignoreTimeScale);
        }

        void SetHoritontal()
        {
            RectTransform rect = _groupContainer.GetComponent<RectTransform>();

            rect.SetLeft(-250);
            rect.SetRight(-250);
        }
        void SetNormal()
        {
            RectTransform rect = _groupContainer.GetComponent<RectTransform>();

            rect.SetLeft(0);
            rect.SetRight(0);
        }
    }

    public void ShowReinforcementLetterTracying(Sprite vocabIcon, string vocabWord, AudioClip vocabClip, bool character = false)
    {
        string hexValueA = ColorUtility.ToHtmlStringRGBA(textColorPrincipal);
        string hexValueB = ColorUtility.ToHtmlStringRGBA(textColorSecondary);

        string firstChar = vocabWord[0].ToString();
        string leftChars = vocabWord.Substring(1);

        firstChar = $"<color=#{hexValueA}><b>{firstChar}</b></color>";
        leftChars = $"<color=#{hexValueB}>{leftChars}</color>";

        _clipVocab = vocabClip;
        _vocabWord.text = firstChar + leftChars;
        _vocabIcon.sprite = vocabIcon;

        Reinforcement(true, character);
    }
    public void ShowReinforcement(Sprite vocabIcon, string vocabWord, AudioClip vocabClip, bool withText = false ,bool character = false)
    {
        _clipVocab = vocabClip;
        _vocabWord.text = vocabWord;
        _vocabIcon.sprite = vocabIcon;

        Reinforcement(withText,character);
    }
    public void ShowReinforcement(SO_Vocabulary vocab, bool withText = false, bool character = false)
    {
        _clipVocab = vocab.ClipReinforcement;
        _vocabIcon.sprite = vocab.SpVocab;

        if (withText) _vocabWord.text = vocab.StrReinforcement;

        Reinforcement(withText, character);
    }


}
