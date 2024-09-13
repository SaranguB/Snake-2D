using System.Collections;
using UnityEngine;

public class SingleUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private SingleSnakeController GreenSnake;
    [SerializeField] private ScoreController scoreController;
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
