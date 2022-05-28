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
       if (i<HP)
       {
           hearts[i].color = Color.gray;
       }
       else
       {
           hearts[i].color  = Color.black;
       }
     }   
    }
}
