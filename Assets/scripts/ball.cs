using System;
using UnityEngine;

public class ball : MonoBehaviour
{
    public static event Action<ball> OBD;
    private Rigidbody2D rb;
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void Die()
    {
        OBD?.Invoke(this);
        Destroy(gameObject);
    }

}
