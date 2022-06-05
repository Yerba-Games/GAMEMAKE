using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public Button primaryButton;
    void OnEnable()
    {
        primaryButton.Select();
    }

 
}
