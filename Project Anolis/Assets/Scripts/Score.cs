using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Score : MonoBehaviour
{
    private static Score instance;
    public static Score Get
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
        AddScore(100);
    }

    private void Update()
    {
        
    }

    public static void AddScore(int value)
    {
        instance.score += value;

        if (instance.score >= instance.scoreTable[instance.scoreIndex])
        {
            instance.scoreIndex++;
        }

        float fillPercentage = instance.score / (float)instance.scoreTable[instance.scoreIndex];
        instance.scoreImage.fillAmount = fillPercentage;

        instance.scoreText.text = instance.score + "/" + instance.scoreTable[instance.scoreIndex];
    }
    
}
