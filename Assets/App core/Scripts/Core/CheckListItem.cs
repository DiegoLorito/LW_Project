using UnityEngine;
using DG.Tweening;

public class CheckListItem : MonoBehaviour
{
    [HideInInspector] public CheckListItemData data;

    public UnityEngine.UI.Image leaderIcon;
    public UnityEngine.UI.Text description;

    public void Init()
    {
        description.text = data.description;
        SetActiveIcon(data.completed);
    }
    public void SetActiveIcon(bool _completed)
    {
        if (_completed)
        {
            leaderIcon.DOColor(ConstantsUI.colorEmerald, 0.25f);
        }
        else
        {
            leaderIcon.DOColor(ConstantsUI.colorLightGray, 0.25f);
        }

        data.completed = _completed; 
    }
}

[System.Serializable]
public class CheckListItemData
{
    public string description;
    public bool completed;
}
