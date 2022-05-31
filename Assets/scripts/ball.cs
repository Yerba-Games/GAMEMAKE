using System;
using UnityEngine;

public class ball : MonoBehaviour
{
    public static event Action<ball> OBD;
    public float thrust;
    public void Die()
    {
        OBD?.Invoke(this);
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.forward);
    }
}
