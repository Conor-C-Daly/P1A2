using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackHandler : MonoBehaviour
{
    // Laser game objects, activated and deactivated depending on state of laser attack
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWindUp;
    [SerializeField] GameObject laserWindDown;
    
    [SerializeField] float cooldown;
    [SerializeField] GameObject damageEffect; // Particle system that plays where laser hits something

    private bool laserReady = true;
    private bool isFiring = false;

    public void Update()
    {
        if (isFiring)
        {
            // shoot a ray 100 units in front of the player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100f, 512);
            // if the ray hits nothing, break out of the function
            if (hit.collider == null) return;

            // Find the position the ray hits and spawn the damageEffect gameObject (which contains the particle system)
            GameObject h = GameObject.Instantiate(damageEffect, new Vector3(hit.point.x, hit.point.y, 0.0f), Quaternion.identity);
            // Access the Health script of the collider game object and have it take damage
            hit.collider.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }

    // Called when player presses the space bar. Input System my beloved.
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (laserReady)
        {
            laserReady = false; // Ensure the laser is only fired once
            StartCoroutine(LaserGoBrrr()); //
        }
    }

    IEnumerator LaserGoBrrr()
    {
        // Activate and deactivate laser game objects depending on the state of the attack

        // Wind up state
        laserWindUp.SetActive(true);
        yield return new WaitForSeconds(2);
        // Firing state
        laserWindUp.SetActive(false);
        laser.SetActive(true);
        isFiring = true;
        yield return new WaitForSeconds(3);
        // Wind down state
        laser.SetActive(false);
        isFiring = false;
        laserWindDown.SetActive(true);
        yield return new WaitForSeconds(2);
        // Cooldown state
        laserWindDown.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        // Ready state
        laserReady = true;
    }
}
