using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Get
    {
        get => instance;
    }
    
    [SerializeField] private Image scoreImage;
    [SerializeField] private Text scoreText;

    [SerializeField] private int[] scoreTable;
    private int scoreIndex = 0;
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreImage.fillAmount = 0;
        scoreText.text = score + "/" + scoreTable[scoreIndex];
    }

    private void Update()
    {
        
    }

    public void AddScore(int value)
    {
        score += value;

        if (score >= scoreTable[scoreIndex])
        {
            score = 0;
            scoreIndex++;
        }

        float fillPercentage = score / (float)scoreTable[scoreIndex];
        scoreImage.fillAmount = fillPercentage;

        scoreText.text = score + "/" + scoreTable[scoreIndex];
    }
    
}
