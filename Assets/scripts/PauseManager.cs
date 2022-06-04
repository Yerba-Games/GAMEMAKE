using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private void Awake()
    {
        pausemenuUI.SetActive(false);
    }
    private void OnEnable()
    {
        pausemenuUI.SetActive(false);
    }
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
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
    public void LoadScene(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
            Resume();
            GameManager.Instance.IsGameStarted = false;
            HPMG.Instance.HP = 3;
            UIMG.Instance.Score = 0;
        }
    }
}