using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPO : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField]private float Time;
    
    public void Expo()
    {
        Text.SetActive(true);
        Disapear();
    }
    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(Time);
        Text.SetActive(false);
    }
}
