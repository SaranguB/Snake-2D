using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        RefreshUI();
    }

    public void IncreaseScore(int point)
    {
        score += point;
        RefreshUI();
    }

    public void DecreaseScore(int point)
    {
        if (score > 0)
        {
            score -= point;
            RefreshUI();
        }
    }

    private void RefreshUI()
    {
        scoreText.text = "Score : " + score;
    }


}
