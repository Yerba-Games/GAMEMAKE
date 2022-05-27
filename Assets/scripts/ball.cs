using System;
using UnityEngine;

public class ball : MonoBehaviour
{
    public static event Action<ball> OBD;
    public void Die()
    {
        OBD?.Invoke(this);
        Destroy(gameObject);
    }
}
