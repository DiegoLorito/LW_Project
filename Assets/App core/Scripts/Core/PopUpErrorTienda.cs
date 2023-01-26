using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUpErrorTienda : MonoBehaviour
{
    public Image background;
    public Transform contendor;
    public Button botonCerrar;

    private void Awake()
    {
        //GameEvents.onShowPopUpErrorShop += MostrarPopUp;
        botonCerrar.onClick.AddListener(OcultarPopUp);
    }
    private void MostrarPopUp()
    {
        contendor.gameObject.SetActive(true);
        contendor.DOScale(1, 0.25f);
    }
    private void OcultarPopUp()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(contendor.DOScale(0, 0.25f))
            .Append(background.DOFade(0, 0.25f))
            .OnComplete(delegate
            {
                background.gameObject.SetActive(false);
                contendor.gameObject.SetActive(false);
                print("Interactuable nuevamente");
            });
    }
    private void OnDestroy()
    {
        //GameEvents.onShowPopUpErrorShop -= MostrarPopUp;
    }
}
