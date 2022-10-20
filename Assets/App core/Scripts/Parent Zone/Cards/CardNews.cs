using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections;
using UnityEngine.Networking;

public class CardNews : MonoBehaviour
{
    //[HideInInspector] public ParentSection parentSection;
    [HideInInspector] public CardNewsData data;

    public GameObject chipNew;
    public Text likesAmount;
    public Text date;
    public TextMeshProUGUI title;
    public RawImage thumbnail;

    private Button button;
    private IEnumerator routineDownload;
    private bool textureLoaded;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        NewsData.instance.currentNewsData = data;
        //parentSection.ChangeSubSection(1,true);
    }
    public void SetData()
    {
        // Verificamos la antiguedad del post para  activar el Chip New
        chipNew.SetActive((System.DateTime.Now - data.date).TotalDays < 30);

        // Establecemos la cantidad de likes
        likesAmount.text = data.likesAmount.ToString();
        // Establecemos la fecha de puclicación
        date.text = data.date.ToString().Substring(0,10);

        // Establecemos el titulo de la noticia
        //int index = data.title.IndexOf(System.Environment.NewLine); 
        //title.text = data.title.Substring(index + System.Environment.NewLine.Length);
        title.text = data.title.Replace("/n","");

        title.text.Trim();

        // Establecemos la miniatura de la noticia
        routineDownload = DownloadImage(data.imageUrl);
        StartCoroutine(routineDownload);
    }
    private void OnEnable()
    {
        if(data.imageUrl != "" && !textureLoaded)
        {
            routineDownload = DownloadImage(data.imageUrl);
            StartCoroutine(routineDownload); 
        }
    }

    private IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(MediaUrl);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.responseCode);
        }
        else
        {
            data.thumbnail = ((DownloadHandlerTexture)www.downloadHandler).texture;
            thumbnail.texture = data.thumbnail;
            textureLoaded = true;
        }
    }

}
