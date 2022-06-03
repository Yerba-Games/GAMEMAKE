using UnityEngine;
using TMPro;
public class UIMG : MonoBehaviour
{
    #region Singleton
    private static UIMG _instance;
    public static UIMG Instance => _instance;


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
    public int Score { get; set; }
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        Block_Script.OnBD += OnBD;
    }
    private void UST(int incresmet)
    {
        this.Score += incresmet;
        string sS = this.Score.ToString().PadLeft(5, '0');
        scoreText.text = $@"scrore:{sS}";
    }
    public void OnBD(Block_Script obj)
    {
        UST(10);   
    }
    public void OnDisable()
    {
        Block_Script.OnBD -= OnBD;
    }
}