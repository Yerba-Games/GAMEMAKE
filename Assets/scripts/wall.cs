using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 patykcentrum = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            ballRb.velocity = Vector2.zero;
            float difference = patykcentrum.x - hitPoint.x;
            if (hitPoint.x < patykcentrum.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 100)), BallsManager.Instance.InitialBallSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 100)), BallsManager.Instance.InitialBallSpeed));
            }
        }
    }
}
