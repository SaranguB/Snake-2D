using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class RandomPowerupGenerator : MonoBehaviour
{
    public BoxCollider2D powerupBoundaryCollider;
    public List<GameObject> food;
    public GameObject selectedFood;

    private float Maxtime = 3.0f;
    private float Timer = 0f;

    private void Start()
    {
        GenerateRandomPowerup();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > Maxtime)
        {
            Timer = 0;
            GenerateRandomPowerup();
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
}
