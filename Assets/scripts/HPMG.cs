using UnityEngine;
using UnityEngine.UI;
public class HPMG : MonoBehaviour
{//players health menager
    #region Singleton
    private static HPMG _instance;
    public static HPMG Instance => _instance;
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
    }
    #endregion
    public int HP;
    [SerializeField] private Image[] hearts;

    private void OnEnable()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled=true;
        }
            UpdateHealth();
    }
    public void UpdateHealth()
    {
     for (int i = 0; i < hearts.Length; i++)
     {
       if (!(i<HP))
       {
            hearts[i].enabled=false;
       }
     }   
    }
}
