using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    private HealthManager _healthManager;
    private int _currentScore;


    private void Awake()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    private void Update()
    {
        ResetScore();
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }

    public void ModifyScore(int scoreValue)
    {
        _currentScore += scoreValue;
        Mathf.Clamp(scoreValue, 0, int.MaxValue);
        Debug.Log("Score: " + _currentScore);
    }

    public void ResetScore()
    {
        var currentHealth = _healthManager.GetHealth();
        if (currentHealth <= 0)
        {
            _currentScore = 0;
        }
    }
}
