using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSliderUI;
    [SerializeField] private HealthManager playerHealth;
    
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreUI;
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSliderUI.maxValue = playerHealth.GetHealth();
    }

    private void Update()
    {
        healthSliderUI.value = playerHealth.GetHealth();
        scoreUI.text = _scoreKeeper.GetCurrentScore().ToString("000000000");
    }
}
