using UnityEngine;

public class dethwall : MonoBehaviour
{
    [SerializeField] private int takenDamage;
    [SerializeField] private HPMG _HPMG;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ball")
        {
            ball Ball = collision.GetComponent<ball>();
            BallsManager.Instance.Balls.Remove(Ball);
            Damage();
            Ball.Die();
        }
    }
    void Damage()
    {
        _HPMG.HP = _HPMG.HP - takenDamage;
        _HPMG.UpdateHealth();
    }
}
