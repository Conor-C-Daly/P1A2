using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class A1NPC : MonoBehaviour
{
    [Header("Wander")]
    public float wanderRadius;
    public Vector3 wanderTarget;
    public Vector3 originPoint;

    [Header("Movement")]
    public float speed;
    public float rotationSpeed;

    [Header("Range")]
    public float range;
    public bool playerInRange;
       
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        originPoint = transform.position;
        wanderTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Vector3.Distance(transform.position, player.position) <= range;

        if(!playerInRange)
            Wander();
        if (playerInRange)
            Chase();
    }

    void Wander()
    {
        //get the position the wander target is in relative to npc's position
        Vector3 relativePos = wanderTarget - transform.position;
        //find the rotation where the npc will face the target
        Quaternion desiredRotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        //make sure it only rotates on the z axis
        desiredRotation.x = 0;
        desiredRotation.y = 0;
        //smoothly rotate towards the target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, wanderTarget, speed * Time.deltaTime);

        //when npc reaches it's wander target, find a new target to move towards
        if (Vector3.Distance(transform.position, wanderTarget) < 0.1)
            wanderTarget = new Vector3(Random.Range(wanderRadius + 2, -wanderRadius + 2), Random.Range(wanderRadius, -wanderRadius), 0);

    }

    void Chase()
    {
        //get the position the player is in relative to npc's current position
        Vector3 relativePos = player.position - transform.position;
        //find the rotation where the npc will face the target
        Quaternion desiredRotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        //make sure it only rotates on the z axis
        desiredRotation.x = 0;
        desiredRotation.y = 0;
        //smoothly rotate towards the target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
