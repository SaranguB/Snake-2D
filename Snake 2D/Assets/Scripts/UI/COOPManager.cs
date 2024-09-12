using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class COOPManager : MonoBehaviour
{
    public SingleSnakeController greenSnake;
    public SingleSnakeController yellowSnake;

    public TextMeshProUGUI wonTitle;

    public void CheckWinner()
    {
        int greenScore = greenSnake.scoreController.GetScore();
        int yellowScore = yellowSnake.scoreController.GetScore();

        if (greenScore > yellowScore)
        {
            wonTitle.text = "Green Snake Is Won";
        }
        else if(greenScore == yellowScore)
        {
            wonTitle.text = "It's A Tie";
        }
        else
        {
            wonTitle.text = "Yellow Snake Is Won";

        }
    }

   
}
