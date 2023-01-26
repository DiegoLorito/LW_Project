using UnityEngine;
using TMPro;

public class EnvironmentSetUp : MonoBehaviour
{
    [SerializeField] private Environment _environment = new Environment();
    [SerializeField] private TMP_Text _txtEnvironment;

    private EnvironmentSetUp Instance;

    [Header("Hide environment and version number?")]
    [SerializeField] private bool _hideDevText;

    public enum Environment
    {
        dev,
        test,
        prod
    };

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        switch (_environment)
        {
            case Environment.dev:
                Constants.PATH_API=Constants.URL_DEV;
                break;
            case Environment.test:
               // Constants.PATH_API = Constants.URL_TEST;
                break;
            case Environment.prod:
                Constants.PATH_API = Constants.URL_PROD;
                break;
        }
        Debug.Log(Constants.PATH_API);
        _txtEnvironment.text = "Environment: "+_environment.ToString() + " Versión: "+ Application.version;

        if (_hideDevText)
        {
            _txtEnvironment.gameObject.SetActive(false);
        }

    }

}
