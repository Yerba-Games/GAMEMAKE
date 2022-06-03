using UnityEngine;

public class Saver : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }
}
