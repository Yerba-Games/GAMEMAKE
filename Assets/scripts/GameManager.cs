using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{   
    [SerializeField]private HPMG _HPMG;
    [SerializeField]private GameObject GS;
    [SerializeField]private GameObject GO;
    [SerializeField]private GameObject Player;
    [SerializeField]private GameObject BMG;

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;
 

    private void Awake()
    {
        if(_instance != null) 
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    public bool IsGameStarted {get; set;}
    public GameObject[] BR;
    public int BRC;
    private void Start()
    {
        ball.OBD += Ball_OBD;
        BR = GameObject.FindGameObjectsWithTag("block");
    }

    private void Ball_OBD(ball obj)
    { 
        if (BallsManager.Instance.Balls.Count <= 0)
        {
            BallsManager.Instance.ResetBalls();
            IsGameStarted = false;
            DeadCheck();
        }
    }
    void DeadCheck()
    { 
        if(_HPMG.HP<=0)
        {
            GS.SetActive(false);
            Player.SetActive(false);
            GO.SetActive(true);
            BMG.SetActive(false);
        }
    }
    public void VictoryCheck()
    {
        BR = GameObject.FindGameObjectsWithTag("block");
        StartCoroutine(count());
    }
    IEnumerator count()
    {
        yield return new WaitForEndOfFrame();
        BRC = BR.Length;
        Victory();
    }
    public void Victory()
    {
        if(BRC<=0)
        {
            SceneManager.LoadScene("game 2");
            IsGameStarted = false;
        }
    }

}
