using UnityEngine;

public class dethwall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ball")
        {
            ball Ball = collision.GetComponent<ball>();
            BallsManager.Instance.Balls.Remove(Ball);
            Ball.Die();
        }
    }
}
