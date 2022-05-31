using UnityEngine;

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
    private void Start()
    {
        ball.OBD += Ball_OBD;
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
}
