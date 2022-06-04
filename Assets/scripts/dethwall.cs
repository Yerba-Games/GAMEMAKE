using UnityEngine;

public class dethwall : MonoBehaviour
{
    #region Singleton
    private static dethwall _instance;
    public static dethwall Instance => _instance;


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
