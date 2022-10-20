using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChestRewardManager : MonoBehaviour
{
    [SerializeField] private Transform[] _rewardsPositions;
    [SerializeField] private SpriteRenderer[] _rewardsSprite;

    [SerializeField] private float duration;
    [SerializeField] private UnityEngine.UI.Image _fade;

    [Space(10)]
    [Header("Chest Coins")]
    [SerializeField] private TMPro.TextMeshProUGUI _coinAmound;
    [SerializeField] private Transform _containerCoins;

    [Space(10)]
    [Header("Chest Sprites")]
    [SerializeField] private Sprite[] _sprNormalChest;
    [SerializeField] private Sprite[] _sprSuperChest;

    [Space(10)]
    [Header("Chest Reward")]
    [SerializeField] private Animator _chestAnimator;
    [SerializeField] private ButtonSprite _chestButton;
    [SerializeField] private Transform _chestContainer;
    [SerializeField] private int _totalTaps;

    [Space(10)]
    [Header("Particles")]
    [SerializeField] private Transform _partSquish;

    private int _rewardsAmouns;
    private Sprite[] _sprChest;
    private Sequence _seqSquishChest;
    private int _currentTap;

    private void Awake()
    {
        _currentTap = 0;
        _seqSquishChest = DOTween.Sequence();
        _chestAnimator.enabled = false;
        _fade.SetAlpha(0);

        for (int i = 0; i < _partSquish.childCount; i++)
        {
            _partSquish.GetChild(i).SetActive(false);
        }
    }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _rewardsAmouns = Rwd_ChestManager.instance.rewards.Length;

        //=== Desactivamos el coin interfase
        _containerCoins.SetActive(false);
        _containerCoins.transform.localScale = Vector2.zero;

        //=== Desactivamos las cards
        for (int i = 0; i < _rewardsSprite.Length; i++)
        {
            _rewardsSprite[i].transform.localScale = Vector2.zero;
            _rewardsSprite[i].gameObject.Disable();
        }

        //=== Verificamos el tipo de cofre
        if (Rwd_ChestManager.instance.hasCoins)
        {
            //=== Si es de monedas
            _sprChest = _sprNormalChest;
            _coinAmound.text = $"+{Rwd_ChestManager.instance.coinAmount}";
        }
        else
        {
            //=== Si es de rewards
            _sprChest = _sprSuperChest;

            SO_LoriItem[] rewards = Rwd_ChestManager.instance.rewards;

            for (int i = 0; i < rewards.Length; i++)
            { 
                _rewardsSprite[i].sprite = rewards[i].icon;
            }
        }

        _chestButton.icon.sprite = _sprChest[0];
    }
    public void ShowRewards()
    {
        _chestButton.icon.sprite = _sprChest[1];

        if (Rwd_ChestManager.instance.hasCoins)
        {
            //=== Si es de monedas
            NormalChest();
        }
        else
        {
            //=== Si es de rewards
            SpecialChest();
        }

        DOVirtual.DelayedCall(duration, ChangeScene);

        void NormalChest()
        {
            _containerCoins.SetActive(true);
            _containerCoins.transform.DOScale(1, 0.25f);
            _containerCoins.transform.DOMove(_rewardsPositions[0].position, 0.25f);
        }
        void SpecialChest()
        {
            //=== Activamos las cards necesarias
            for (int i = 0; i < _rewardsAmouns; i++)
            {
                _rewardsSprite[i].gameObject.Enable();
            }

            //=== Dependiendo de la cantidad de rewads posicionamos las cards
            switch (_rewardsAmouns)
            {
                //=== 1 rewards
                case 1:
                    _rewardsSprite[0].transform.DOScale(1, 0.25f);
                    _rewardsSprite[0].transform.DOMove(_rewardsPositions[0].position, 0.25f);
                    break;
                //=== 2 rewards
                case 2:
                    _rewardsSprite[0].transform.DOScale(1, 0.25f);
                    _rewardsSprite[1].transform.DOScale(1, 0.25f);

                    _rewardsSprite[0].transform.DOMove(_rewardsPositions[3].position, 0.25f);
                    _rewardsSprite[1].transform.DOMove(_rewardsPositions[4].position, 0.25f);
                    break;
                //=== 3 rewards
                case 3:
                    _rewardsSprite[0].transform.DOScale(1, 0.25f);
                    _rewardsSprite[1].transform.DOScale(1, 0.25f);
                    _rewardsSprite[2].transform.DOScale(1, 0.25f);

                    _rewardsSprite[0].transform.DOMove(_rewardsPositions[1].position, 0.25f);
                    _rewardsSprite[1].transform.DOMove(_rewardsPositions[0].position, 0.25f);
                    _rewardsSprite[2].transform.DOMove(_rewardsPositions[2].position, 0.25f);
                    break;
                default:
                    break;
            }
        }
        void ChangeScene()
        {
            GameEvents.ButtonsSpriteInteractable(false);
            GameEvents.CanvasInteractable(false);

            _fade.DOFade(1,0.5f).OnComplete(()=>
            {
                //SceneManager.LoadScene("App Hub");
                SceneManager.LoadScene("Reward Chest");
            });
        }
    }
    public void ChestInteraction()
    {
        _currentTap++;

        if(_currentTap >= _totalTaps)
        {
            _chestButton.interactable = false;
            _chestAnimator.enabled = true;
        }
        else
        {
            SquishChest();
        }

        void SquishChest()
        {
            Debug.Log("Sonido de cofre tratando de abrir");

            //=== Pooling Particulas
            if (_partSquish.GetChild(0).gameObject.activeInHierarchy)
            {
                GameObject part = _partSquish.GetChild(0).gameObject;
                Instantiate(part, _partSquish);
            }
            else
            {
                _partSquish.GetChild(0).gameObject.SetActive(true);
                _partSquish.GetChild(0).SetAsLastSibling();
            }

            //=== Animacion de Squish
            _seqSquishChest = DOTween.Sequence();

            _seqSquishChest
                .Append(_chestContainer.DOScale(0.9f, 0.1f))
                .Append(_chestContainer.DOScale(1.0f, 0.1f));
        }
    }
}