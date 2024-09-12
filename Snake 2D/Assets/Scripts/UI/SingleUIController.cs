using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUIController : MonoBehaviour
{

    public GameObject gameOver;
    public SingleSnakeController GreenSnake;
    public ScoreController scoreController;
    private void Update()
    {

        if (GreenSnake.GetPlayerState() == PlayerState.DEAD)
        {
            StartCoroutine(EnableGameOverForSinglePlayer());
        }



    }
    private IEnumerator EnableGameOverForSinglePlayer()
    {
        yield return new WaitForSeconds(3f);
        gameOver.SetActive(true);
        scoreController.SetHighScore();
        scoreController.UpdateScoreUI();
    }
}
