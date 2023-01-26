using UnityEngine;
using UnityEngine.UI;

public class CardUnitResume : MonoBehaviour
{
    //[HideInInspector] public ParentSection parentSection;
    [HideInInspector] public UnitData data;

    public GameObject chipNew;

    public Image thumbnail;
    public Image background;

    public Text Name;
    public Text number; 
    public Text progressText;

    public Image progressFill;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        UnitsData.instance.currentCard = data;
        UnitsData.instance.SetUnitDetails();
        //parentSection.ChangeSubSection(1,true,true);
    }
    public void SetData()
    {
        // Verificamos la antiguedad del post para  activar el Chip New
        //chipNew.SetActive((System.DateTime.Now - data.date).TotalDays < 30);
         
        Name.text = data.core.Name;
        number.text = "Unit " + data.index;

        //progressText.text = data.currenProgress.ToString() + "/" + data.totalProgress.ToString();

        thumbnail.sprite = data.thumbnail;
        background.color = data.core.colorMiddleground;

        //progressFill.fillAmount = data.currenProgress / data.totalProgress;
    }
}
