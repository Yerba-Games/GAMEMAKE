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
    public TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI Level;
    private int LevelNum;
    private void OnEnable()
    {
        LevelNum = 1;
        Block_Script.OnBD += OnBD;
        Level.text = $@"LEVEL:{LevelNum}";
    }
    private void UST(int incresmet)
    {
        this.Score += incresmet;
        string sS = this.Score.ToString();
        scoreText.text = "SCORE:"+"\n"+sS;
        finalScore.text = $@"YOUR FINAL SCORE:{sS}";
    }
    public void OnBD(Block_Script obj)
    {
        UST(10);   
    }
    public void OnDisable()
    {
        scoreText.text = "SCORE:" + "\n" + "0";
        Block_Script.OnBD -= OnBD;
    }
    private void OnLevelWasLoaded(int level)
    {
        LevelNum += 1;
    }
}