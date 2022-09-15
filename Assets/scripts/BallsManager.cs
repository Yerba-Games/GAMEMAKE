using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    #region Singleton
    private static BallsManager _instance;
    public static BallsManager Instance => _instance;
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
    [SerializeField]
    private ball ballPrefab;
    private ball initialBall;
    private Rigidbody2D initialBallrb;
    public float InitialBallSpeed = 250;
    public List<ball> Balls { get; set; }
    private void Start()
    {
        InitBall();
    }
    public void Fire()
    {   
        if(!GameManager.Instance.IsGameStarted)
        {
            initialBallrb.isKinematic = false;
            initialBallrb.AddForce(new Vector2(0,InitialBallSpeed));
            GameManager.Instance.IsGameStarted = true;
        }
    }
    private void Update()
    {
        
        if(!GameManager.Instance.IsGameStarted)
        {
            // ustawia pozycj� kulki do patyka
            Vector3 pp = plater.Instance.gameObject.transform.position;
            Vector3 bp = new Vector3(pp.x, pp.y+.27f,0);
            initialBall.transform.position = bp;
        }
        
    }
    private void InitBall()
    {
        //bierze pozycj� kulki od pa��ka? tego g�wna na dole kt�rym gramy
        Vector3 pp = plater.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(pp.x,pp.y+.27f,0);
        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallrb = initialBall.GetComponent<Rigidbody2D>();
        this.Balls = new List<ball>
        {
            initialBall
        }; 
    }
    public void ResetBalls()
    {
        foreach(var ball in this.Balls.ToList())
        {
            Destroy(ball.gameObject);
        }
        InitBall();
    }
}
