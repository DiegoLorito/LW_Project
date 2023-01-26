using UnityEngine;
using UnityEngine.UI;

public class BotonVolverPantalla : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { BackScreen(); });
    }
    private void BackScreen()
    {
        GameEvents.BackScreen();
    }

}
