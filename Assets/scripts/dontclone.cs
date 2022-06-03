using UnityEngine;

public class dontclone : MonoBehaviour
{
    #region Singleton
    private static dontclone _instance;
    public static dontclone Instance => _instance;
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
}
