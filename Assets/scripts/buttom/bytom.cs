using UnityEngine;
using UnityEngine.SceneManagement;
public class bytom : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void LoadScene(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
}
