using UnityEngine;

public class CardUser : MonoBehaviour
{
    [HideInInspector] public UserData data;

    public UnityEngine.UI.Text userName;
    public UnityEngine.UI.Text unitWorld;
    public UnityEngine.UI.Image avatar;
    public UnityEngine.UI.Image background;
    public UnityEngine.UI.Image checkIcon;
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Button buttonEdit;

    public GameObject check;
     
    public void SetData()
    {
        SO_WorldCore world = LocalData.Instance.GetDataWorld("UP");

        //int curUnit = data.CurrentUnit.index; DESCOMENTAR 
        int curUnit = 1;

        userName.text = data.name;
        unitWorld.text = world.Name.FirstCharToUpper() + " - Unit " + curUnit.ToString();
        avatar.sprite = LocalData.Instance.GetDataAvatar(data.avatarCode).icon;

        unitWorld.color = world.color;
        background.color = world.color;
        checkIcon.color = world.color;

        EnableCheck();
    }
    public void EnableCheck()=> check.SetActive(AppServerData.instance.dataCurrentUser.id == data.id);
    public void ShowScreenEditUser()
    {

    }
}
