using UnityEngine;

public class DialogCustom : MonoBehaviour
{
    [HideInInspector] public ControladorDialog controller;

    public virtual void Init() { }
    public virtual void SetData() { }
}
