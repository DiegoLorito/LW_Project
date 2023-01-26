using UnityEngine;

public class CardProfile : MonoBehaviour
{
    [HideInInspector] public CardProfileData data;

    public UnityEngine.UI.Text Name;
    public UnityEngine.UI.Text email;

    public void SetData()
    {
        Name.text = data.Name;
        email.text = data.email;
    }
}
