using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUIController : MonoBehaviour
{

    public GameObject gameOver;
    public SingleSnakeController GreenSnake;
    public ScoreController scoreController;
    private bool ISGameOverTriggered = false;
    private void Update()
    {

        if (GreenSnake.GetPlayerState() == PlayerState.DEAD && !ISGameOverTriggered)
        {
            ISGameOverTriggered = true;
            SoundManager.Instance.PlayMusic(Sounds.GAME_FINISHED);
            StartCoroutine(EnableGameOverForSinglePlayer());
        }



    }
    private IEnumerator EnableGameOverForSinglePlayer()
    {
        yield return new WaitForSeconds(1f);
        gameOver.SetActive(true);
        scoreController.SetHighScore();
        scoreController.UpdateScoreUI();
    }
}
