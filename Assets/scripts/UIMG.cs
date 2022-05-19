using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIMG : MonoBehaviour
{
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