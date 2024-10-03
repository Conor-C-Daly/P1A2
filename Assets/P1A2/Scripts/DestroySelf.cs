using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private float timer;
    private void Update()
    {
        //Increment the timer over time
        timer += Time.deltaTime;
        // Once the timer exceeds 10, destroy the game object this script is attached to.
        if(timer > 10)
        {
            Destroy(gameObject);
        }
    }
}
