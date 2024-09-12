using UnityEngine;

public class FoodController : MonoBehaviour
{
    private float maxRemoveTime = 5f;
    private float removeTimer = 0f;

    public SingleSnakeController snakeController;

    private void Update()
    {
        if (SettingsController.Instance.GetGameState() == GameState.PLAY_MODE)
        {

            RemoveFood();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    private void RemoveFood()
    {

        removeTimer += Time.deltaTime;
        if (removeTimer > maxRemoveTime)
        {
           
            Destroy(this.gameObject);
            removeTimer = 0;
        }
    }
}
