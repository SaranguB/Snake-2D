using System.Collections.Generic;
using UnityEngine;

public class RandomPowerupGenerator : MonoBehaviour
{
    [SerializeField] private BoxCollider2D powerupBoundaryCollider;
    [SerializeField] private List<GameObject> food;
    private GameObject selectedFood;

    [SerializeField] private SingleSnakeController GreenSnakecontroller;
    [SerializeField] private SingleSnakeController YellowSnakecontroller;

    private float Maxtime = 3.0f;
    private float Timer = 0f;


    private void Start()
    {

        GenerateRandomPowerup();
    }

    private void Update()
    {
        if (SettingsController.Instance.GetGameState() == GameState.PLAY_MODE &&
            GreenSnakecontroller.GetPlayerState() == PlayerState.ALIVE)
        {
            Timer += Time.deltaTime;
            Maxtime = UnityEngine.Random.Range(1, 5f);
            if (Timer > Maxtime)
            {
                GenerateRandomPowerup();
                Timer = 0;

            }
        }

    }

    private void GenerateRandomPowerup()
    {
        Bounds bounds = powerupBoundaryCollider.bounds;
        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

        Vector2 randomPosition = new Vector2(Mathf.Round(x), Mathf.Round(y));

        int randomIntex = UnityEngine.Random.Range(0, food.Count);
        selectedFood = food[randomIntex];
        Instantiate(selectedFood, randomPosition, Quaternion.identity);

    }

    /* private int GenerateRandomWeightedIndex()
     {
         int totalWeight = 0;

         foreach (int weight in powerupWeights)
         {
             totalWeight += weight;
         }

         if (totalWeight < 0)
         {
             return 0;
         }

         int randomWeight = UnityEngine.Random.Range(0, totalWeight);
         //Debug.Log("weight " + randomWeight);

         int currentWeightSum = 0;

         for (int i = 0; i < powerupWeights.Count; i++)
         {
             currentWeightSum += powerupWeights[i];
             if (currentWeightSum > randomWeight)
             {
                 return i;
             }

         }
         return 0;


     }*/
}
