using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySensor : MonoBehaviour
{
    private List<GameObject> asteroidsInRange = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in asteroidsInRange)
        {

            Debug.DrawLine(transform.position, go.transform.position, color: Color.cyan);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision game object is on the NPCProjectiles layer
        // If it is, add it to the asteroidsInRange list
        if(collision.gameObject.layer == 9)
        {
            asteroidsInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Remove game object from the list if it's on the NPCProjectiles layer
        if (collision.gameObject.layer == 9)
        {
            asteroidsInRange.Remove(collision.gameObject);
        }
    }
}
