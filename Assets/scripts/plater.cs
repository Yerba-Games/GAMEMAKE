using System.Collections;
using System.Collections.Generic;
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
    private float inputY;
    public float speed = 9999f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        inputX = movementVector.x;
        inputY = movementVector.y;
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
            Vector3 patykcentrum = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            ballRb.velocity = Vector2.zero;
            float difference = patykcentrum.x - hitPoint.x;
            if (hitPoint.x < patykcentrum.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference*200)), BallsManager.Instance.InitialBallSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), BallsManager.Instance.InitialBallSpeed));
            }
        }
    }
}
