using TMPro;
using UnityEngine;

public class COOPManager : MonoBehaviour
{
    [SerializeField] private SingleSnakeController greenSnake;
    [SerializeField] private SingleSnakeController yellowSnake;

    [SerializeField] private TextMeshProUGUI wonTitle;

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
