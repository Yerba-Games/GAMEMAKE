using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{   
    [SerializeField]private HPMG _HPMG;
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
        Debug.Log(BRC);
    }
    private void FixedUpdate()
    { 
        BRC = BR.Length;
        Victory();
        Debug.Log(BRC);
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
            Debug.Log("GameOver");
        }
    }
    public void Victory()
    {
        if(BRC<=0)
        {
            SceneManager.LoadScene("game");
        }
    }

}
