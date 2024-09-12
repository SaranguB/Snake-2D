using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private TextMeshProUGUI highscore;
    private void Start()
    {
        highscore = GetComponent<TextMeshProUGUI>();
        DisplayScore();
    }

    private void DisplayScore()
    {

        int high = PlayerPrefs.GetInt("HighScore", 0);
        highscore.text = "High Score : " + high.ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
