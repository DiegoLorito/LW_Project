using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogReward : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Image background;
    [SerializeField] private RectTransform panel;

    [SerializeField] private Image[] rewardIcons;
    [SerializeField] private Text loricoinsAmount;

    [SerializeField] private GameObject layoutReward;
    [SerializeField] private GameObject layoutLoricoin;

    [SerializeField] private float duration = 2.0f;

    [Header("Chest Settings")]
    [SerializeField] private GameObject normalChest;
    [SerializeField] private GameObject specialChest;

    private void Awake()
    {
        GameEvents.onRewardNormalChest += RewardNormalChest;
        GameEvents.onRewardSpecialChest += RewardSpecialChest;
        GameEvents.onRewardContent += RewardContent;
    }

    public void RewardNormalChest()
    {
        Reset();

        normalChest.Enable();

        ShowPanel();
    }
    public void RewardSpecialChest(SO_LoriItem[] rewards)
    {
        Reset();

        for (int i = 0; i < rewards.Length; i++)
        {
            rewardIcons[i].sprite = rewards[i].icon;
        }

        specialChest.Enable();

        ShowPanel();
    }
    public void RewardContent(SO_LoriItem[] rewards)
    {
        Reset();

        for (int i = 0; i < rewards.Length; i++)
        {
            rewardIcons[i].sprite = rewards[i].icon;
            rewardIcons[i].gameObject.Enable();
        }

        layoutReward.Enable();

        ShowPanel();

        Invoke("HidePanel", duration);
    }

    public void OpenNormalChest()
    {
        normalChest.Disable();
        layoutLoricoin.Enable();

        Invoke("HidePanel", duration);
    }
    public void OpenSpecialChest()
    {
        specialChest.Disable();
        layoutReward.Enable();

        Invoke("HidePanel", duration);
    }

    private void Reset()
    {
        normalChest.Disable();
        specialChest.Disable();
        layoutLoricoin.Disable();
        layoutReward.Disable();

        for (int i = 0; i < rewardIcons.Length; i++)
        {
            rewardIcons[i].gameObject.SetActive(false);
        }
    }
    private void ShowPanel()
    {
        GameEvents.CanvasInteractable(false);

        background.color.SetAlpha(0);
        panel.localScale = Vector3.zero;

        background.gameObject.Enable();
        panel.gameObject.Enable();

        background.DOFade(0.3f, 0.5f);
        panel.DOScale(1, 0.5f).OnComplete(()=> GameEvents.CanvasInteractable(true));
    }
    private void HidePanel()
    {
        GameEvents.CanvasInteractable(false);

        background.DOFade(0, 0.5f);
        panel.DOScale(0, 0.5f).OnComplete(()=>
        {
            panel.gameObject.Disable();
            background.gameObject.Disable();

            GameEvents.CanvasInteractable(true);
        });
    }

    private void OnDestroy()
    {
        GameEvents.onRewardNormalChest -= RewardNormalChest;
        GameEvents.onRewardSpecialChest -= RewardSpecialChest;
        GameEvents.onRewardContent -= RewardContent;
    }

}
