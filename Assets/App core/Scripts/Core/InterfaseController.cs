using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaseController : MonoBehaviour
{
    public CanvasGroup _cGroup;
    private void Awake()
    {
        GameEvents.onCanvasInteractable += CanvasInteractable;
    }
    private void CanvasInteractable(bool value)
    {
        _cGroup.interactable = value;
        _cGroup.blocksRaycasts = value;
    }
    private void OnDestroy()
    {
        GameEvents.onCanvasInteractable -= CanvasInteractable;
    }
}
