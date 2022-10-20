using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPersistentSingleton : MonoBehaviour
{
    public static TestPersistentSingleton Instance { get; private set; }

    public string letter; 

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) SceneManager.LoadScene("TestSceneA");
        if (Input.GetKeyDown(KeyCode.W)) SceneManager.LoadScene("TestSceneB");
    }
}
