using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    private float maxRemoveTime = 5f;
    private float removeTimer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    private void RemoveFood()
    {
        //Debug.Log("Entered");

        removeTimer += Time.deltaTime;
        if (removeTimer > maxRemoveTime)
        {
            // Debug.Log("Destroyed");
            Destroy(this.gameObject);
            removeTimer = 0;
        }
    }

}
