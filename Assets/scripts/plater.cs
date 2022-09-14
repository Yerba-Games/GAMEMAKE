using UnityEngine;
using UnityEngine.InputSystem;

public class plater : MonoBehaviour
{
    #region Singleton
    private static plater _instance;
    public static plater Instance => _instance;
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
    private Rigidbody2D rb;
    private float inputX;
    private float speed,BSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GameObject.FindWithTag("GameController").GetComponent<GameManager>().speed;
        BSpeed = GameObject.FindWithTag("GameController").GetComponent<GameManager>().BallSpeed;
    }

    private void OnLevelWasLoaded(int level)
    {
        speed = GameObject.FindWithTag("GameController").GetComponent<GameManager>().speed;
        BSpeed = GameObject.FindWithTag("GameController").GetComponent<GameManager>().BallSpeed;
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        inputX = movementVector.x;
    }
    public void OnFire()
    {
        BallsManager.Instance.Fire();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(inputX * speed * Time.deltaTime, 0,0);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 stickCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            ballRb.velocity = Vector2.zero;
            float difference = stickCenter.x - hitPoint.x;
            if (hitPoint.x < stickCenter.x)
            //based on difference between where the ball hits and the center of stick adds a deviation to a ball
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference*200)), BallsManager.Instance.InitialBallSpeed+BSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), BallsManager.Instance.InitialBallSpeed+BSpeed));
            }
        }
    }
}
