using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppScreen : MonoBehaviour
{
    public AppScreenController controller;

    public GameObject screen;

    public virtual void Init() { }
    public virtual void LoadContent() { }
    public virtual void ContentLoaded() { }
    public virtual void ContentSetted() 
    {
        GameEvents.CanvasInteractable(true);
    }

    public void EnableScreen(bool enable)
    {
        screen.SetActive(enable);
    }
}
