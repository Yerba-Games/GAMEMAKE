using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private string SpawnTarget()
    {
        throw new NotImplementedException();
    }

    private void Awake()
    {
        if(_instance != null) 
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    public bool IsGameStarted {get; set;}
}
