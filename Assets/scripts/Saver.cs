using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            Destroy(gameObject);
        }

    }
}
