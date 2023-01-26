using UnityEngine;
using UnityEngine.UI;

public class CardUserResume : MonoBehaviour
{
    [HideInInspector] public int index;
    [HideInInspector] public int avatarId;
    [HideInInspector] public UserData userData;
    [HideInInspector] public ScreenUsers controller;

    public Button button;
    public Image background;
    public Image avatar;

    public Text txtName;
    public Text txtInfo;

    public GameObject check;

    private void Start()
    {
        button.onClick.AddListener(delegate { SelectUser(); });
    }
    public void SetData()
    {
        SO_WorldCore dataWorld = LocalData.Instance.GetDataWorld("UP");

        txtName.text = userData.name;
        txtInfo.text = dataWorld.Name.FirstCharToUpper() + " - " + "Unit " + (userData.indexCurUnit + 1).ToString();

        txtInfo.color = dataWorld.color;
        background.color = dataWorld.color;
        check.transform.GetChild(0).GetComponent<Image>().color = dataWorld.color;

        avatar.sprite = userData.Avatar.icon;
    }
    private void SelectUser()
    {
        GameEvents.CanvasInteractable(false);

        AppServerData.instance.dataCurrentUser = userData;
        ControladorData.instance.data.user = userData;
        ControladorData.instance.SaveAppData();

        GameEvents.TransitionScene("App Hub");
    }

}
