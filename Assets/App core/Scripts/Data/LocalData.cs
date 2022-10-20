using System.Collections.Generic;
using UnityEngine;

public class LocalData : MonoBehaviour
{
    public static LocalData Instance;

    [SerializeField] private SO_DataAvatars dataAvatars;
    [SerializeField] private SO_DataWorlds dataWorlds;
    [SerializeField] private SO_DataTemplates dataTemplates;

    public Dictionary<string, SO_Avatar> DataAvatars => dataAvatars.Data;
    public Dictionary<string, SO_WorldCore> DataWorlds => dataWorlds.Data;
    public Dictionary<string, SO_TemplateData> DataTemplates => dataTemplates.Data;


    public List<SO_Avatar> DataAvatarsArray => new List<SO_Avatar>(dataAvatars.Data.Values);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }

        dataAvatars.Initialize();
        dataWorlds.Initialize();
        dataTemplates.Initialize();
    }

  

    public SO_Avatar GetDataAvatar(string code)
    {
        if (dataAvatars == null)
        {
            Debug.LogWarning("No se asign� el CATALOGO DE AVATARS");
            return null;
        }

        if (!dataAvatars.Data.ContainsKey(code))
        {
            Debug.LogWarning("No se encontro el c�digo de AVATAR en Cat�logo");
            return null;
        }

        return dataAvatars.Data[code];
    }
    public SO_WorldCore GetDataWorld(string code)
    {
        if (!dataWorlds.Data.ContainsKey(code))
        {
            Debug.LogWarning("No se encontro el c�digo del MUNDO en Cat�logo");
            return null;
        }

        return dataWorlds.Data[code];
    }
    public SO_TemplateData GetDataTemplate(string code)
    {
        if (!dataTemplates.Data.ContainsKey(code))
        {
            Debug.LogWarning("No se encontro el c�digo del TEMPLATE en Cat�logo");
            return null;
        }

        return dataTemplates.Data[code];
    }
}
