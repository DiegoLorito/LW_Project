using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardContent : MonoBehaviour
{
    [HideInInspector] public SO_UnitCore unit;
    [HideInInspector] public ContentData data;

    public Text txtName;
    public Image icon;
    public Image iconType;
    public Image background;
    public Button button;


    public GameObject check;
    public GameObject tagEpisode;

    public Sprite[] spritesType;

    public void SetData()
    {
        txtName.text = data.Name;
        icon.sprite = data.icon;

        // Cambiamos el icono si es video o juego
        switch (data.type)
        {
            case ContentData.Type.game:
                iconType.gameObject.SetActive(true);
                iconType.sprite = spritesType[0];
                background.color = unit.colorMiddleground;
                break;
            case ContentData.Type.video:
                iconType.gameObject.SetActive(true);
                iconType.sprite = spritesType[1];
                background.color = unit.colorMiddleground;
                break;
            case ContentData.Type.episode:
                tagEpisode.SetActive(true);
                break;
            default:
                break;
        }

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }
    public void SetContentComplete(bool value)
    {
        //data.completed = value;
        check.SetActive(value);
    }

    private void OnClick()
    {
        PlayerPrefs.SetString("LastCode",data.code);
        PlayerPrefs.SetString("scn", data.code);
        PlayerPrefs.SetString("modo", data.type.ToString());
        //LocalData.SetContentId(data.id);
        LocalSavedData.SetComeFromInteraction(true);

        switch (data.type)
        {
            case ContentData.Type.game:
                SceneManager.LoadScene("Template");
                break;
            case ContentData.Type.video:
                SceneManager.LoadScene("VideoTemplate");
                break;
            case ContentData.Type.episode:
                SceneManager.LoadScene("VideoTemplate");
                break;
            default:
                break;
        }
    }
}
