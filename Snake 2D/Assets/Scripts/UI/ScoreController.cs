
using TMPro;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private int highScore = 0;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        RefreshScoreUI();
        //ResetPlayerHighScore();
    }

    private void Update()
    {
        SetHighScore();
    }

    private void ResetPlayerHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void IncreaseScore(int point)
    {
        score += point;

        RefreshScoreUI();
    }

    public void DecreaseScore(int point)
    {
        if (score > 0)
        {
            score -= point;
            RefreshScoreUI();
        }
    }

    private void RefreshScoreUI()
    {
        scoreText.text = "Score : " + score;
    }

    public void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            UpdateScoreUI();

        }
    }

    public void UpdateScoreUI()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        //  Debug.Log("Higher Score = " + highScore);
        // Debug.Log("Score = " + score);

        if (score == highScore)
        {
            highScoreText.text = "New High Score : " + score;
        }
        else
        {
            highScoreText.text = "Your Score : " + score;

        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
