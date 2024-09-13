using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private SingleSnakeController GreenSnake;
    [SerializeField] private SingleSnakeController YellowSnake;
    private bool ISGameOverTriggered = false;


    [SerializeField] private COOPManager coopManager;


    private void Update()
    {
        if ((YellowSnake.GetPlayerState() == PlayerState.DEAD || GreenSnake.GetPlayerState() == PlayerState.DEAD) &&
            !ISGameOverTriggered)
        {

            ISGameOverTriggered = true;
            SoundManager.Instance.PlayMusic(Sounds.GAME_FINISHED);
            StartCoroutine(EnableGameOverForCOOP());
        }


    }

    private IEnumerator EnableGameOverForCOOP()
    {
        yield return new WaitForSeconds(3f);
        gameOver.SetActive(true);
        coopManager.CheckWinner();

    }




}
