using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackHandler : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWindUp;
    [SerializeField] GameObject laserWindDown;
    [SerializeField] float cooldown;
    [SerializeField] GameObject damageEffect;


    private bool laserReady = true;
    private bool isFiring = false;

    public void Update()
    {
        if (isFiring)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100f, 512);
            if (hit.collider == null) return;

            GameObject h = GameObject.Instantiate(damageEffect, new Vector3(hit.point.x, hit.point.y, 0.0f), Quaternion.identity);
            hit.collider.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (laserReady)
        {
            laserReady = false;
            StartCoroutine(LaserGoBrrr());
        }
    }

    IEnumerator LaserGoBrrr()
    {
        laserWindUp.SetActive(true);
        yield return new WaitForSeconds(2);
        laserWindUp.SetActive(false);
        laser.SetActive(true);
        isFiring = true;
        yield return new WaitForSeconds(3);
        laser.SetActive(false);
        isFiring = false;
        laserWindDown.SetActive(true);
        yield return new WaitForSeconds(2);
        laserWindDown.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        laserReady = true;
    }
}
