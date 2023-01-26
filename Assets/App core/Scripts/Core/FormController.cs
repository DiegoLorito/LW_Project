using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FormController : MonoBehaviour
{
    public InputField inputDay;
    public InputField inputMonth;
    public InputField inputYear;

    private void Start()
    {
        inputDay.interactable = false;
        inputMonth.interactable = false;
        //inputYear.interactable = false;
    }

    public void ValidateInputYear()
    {
        if(inputYear.text != "")
        {
            inputMonth.GetComponent<CanvasGroup>().DOFade(1, 0.25f).OnComplete(delegate { inputMonth.interactable = true; });
        }
        else
        {
            inputDay.text = "";
            inputMonth.text = "";
            inputDay.interactable = false;
            inputMonth.interactable = false;
        }
    }
    public void ValidateInputMonth()
    {
        if (inputMonth.text != "")
        {
            inputDay.GetComponent<CanvasGroup>().DOFade(1, 0.25f).OnComplete(delegate { inputDay.interactable = true; });
        }
        else
        {
            inputDay.text = "";
            inputDay.interactable = false;
        }
    }
}
