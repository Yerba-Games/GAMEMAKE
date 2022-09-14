using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    #region Singleton
    private static Saver _instance;
    public static Saver Instance => _instance;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        SceneManager.sceneLoaded += this.OnLoadCallback;
    }
    #endregion
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
