using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    private void Awake()
    {
        pausemenuUI.SetActive(false);
    }
    void OnPauseMenu()
    {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }
    public void Unpause()
    {
        Resume();
    }
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}