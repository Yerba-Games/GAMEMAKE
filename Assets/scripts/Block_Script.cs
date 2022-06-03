using UnityEngine;
using System;

public class Block_Script : MonoBehaviour
{
    public int HP = 1;
    public static event Action<Block_Script> OnBD;
    public GameObject Death;
    public float AddSpeed = 100;

    void OnCollisionEnter2D(Collision2D coll)
    {
;
        if (coll.gameObject.tag == "ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 patykcentrum = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            ballRb.velocity = Vector2.zero;
            float difference = patykcentrum.x - hitPoint.x;
            if (hitPoint.x < patykcentrum.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), AddSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), AddSpeed));
            }
        }
        ball Ball = coll.gameObject.GetComponent<ball>();
        APCL(Ball);
        
    }
    private void APCL(ball Ball)
    {
        this.HP--;
        if(this.HP<=0)
        {
            OnBD?.Invoke(this);
            gameObject.transform.tag = "deadBlock";
            Instantiate(Death, transform.position, transform.rotation);
            GameManager.Instance.VictoryCheck();
            Destroy(this.gameObject);
        }
        else
        {
            //potem bedzie zmieniaæ sprita
        }
    }
}
