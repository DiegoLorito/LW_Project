using UnityEngine;

public class ServerData : MonoBehaviour
{
    public static ServerData Instance;

    public SO_UnitGroup dataUnits;
    public SO_ContentGroup dataContents;


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

        //==== TEMP ====//

        dataUnits.SetData();
    }

    public SO_UnitCore DataAvatar(string code)
    {
        if (!dataUnits.Data.ContainsKey(code))
        {
            Debug.LogWarning("No se encontro el código de la UNIDAD en Catálogo");
            return null;
        }

        return dataUnits.Data[code];
    }
    public SO_ContentCore DataContent(string code)
    {
        if (!dataContents.Data.ContainsKey(code))
        {
            Debug.LogWarning("No se encontro el código de la CONTENIDO en Catálogo");
            return null;
        }

        return dataContents.Data[code];
    }
}
