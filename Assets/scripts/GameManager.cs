using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{   
    [SerializeField]private HPMG _HPMG;
    [SerializeField]private GameObject GS;
    [SerializeField]private GameObject GO;
    [SerializeField]private GameObject Player;

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
    //Balls Remaing - based on list of GameObjects
    public int BRC;
    //Balls Remaing Count - simply converst list to int making it able to check with if statment
    private void Start()
    {
        ball.OBD += Ball_OBD;
        BR = GameObject.FindGameObjectsWithTag("block");
    }
    //OBD-On Ball Destrucion
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
        }
    }
    private void OnEnable()
    {
        GS.SetActive(true);
        Player.SetActive(true);
        GO.SetActive(false);
    }
    /*remeber kids if you need to count something in unity do it at beginig of creating it
     * but if you don't
     * WELCOME TO SHIT HELL of FUNCION*/
    public void VictoryCheck()
    {
        BR = GameObject.FindGameObjectsWithTag("block");
        StartCoroutine(count());
    }
    IEnumerator count()//guess which take longer than frame to create resoving in endles relodes
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
