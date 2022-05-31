using UnityEngine;
using UnityEngine.UI;

public class HPMG : MonoBehaviour
{
    public int HP;
    [SerializeField] private Image[] hearts;

    private void Start()
    {
            UpdateHealth();
    }
    public void UpdateHealth()
    {
     for (int i = 0; i < hearts.Length; i++)
     {
       if (!(i<HP))
       {
          Destroy(hearts[i]);
       }
     }   
    }
}
