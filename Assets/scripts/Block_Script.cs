using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block_Script : MonoBehaviour
{
    public int HP = 1;
    public static event Action<Block_Script> OnBD;
    public GameObject Death;
    [SerializeField] private GameManager _GM;
    void OnCollisionEnter2D(Collision2D collision)
    {
        ball Ball = collision.gameObject.GetComponent<ball>();
        APCL(Ball);
        
    }
    private void APCL(ball Ball)
    {
        this.HP--;
        if(this.HP<=0)
        {
            OnBD?.Invoke(this);
            Instantiate(Death, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            //potem bedzie zmieniaæ sprita
        }
    }
}
