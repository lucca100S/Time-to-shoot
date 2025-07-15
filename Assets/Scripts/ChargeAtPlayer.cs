using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAtPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float initialChargePosition;
    private Vector3 chargeDirection;

    public float chargeSpeed;
    public float chargingDelay = 1f;
    private float timer = 0f;

    private bool isCharging = false;

    private float velocityModifier;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalPosition = transform.position.z;

        velocityModifier = VelocityController.instance.velocityModifier;

        // If enemy is at the top of the screen, charge at enemy
        if (playerTransform != null && (Mathf.Abs(verticalPosition) < initialChargePosition || isCharging))
        {
            Charge();
        }
    }

    void Charge()
    {
        GetComponent<Move>().enabled = false; // Disables standard foward movement

        if (!isCharging)
        {
            transform.LookAt(playerTransform.position); // Points at player
        }

        // If enemy is ready to charge (waited for chargingDelay seconds), charge at player.
        // If enemy is not charging yet, saved charge direction
        if (timer > chargingDelay && isCharging == false)
        {
            isCharging = true;
            chargeDirection = playerTransform.position - transform.position; // Vector between player and enemy
            transform.Translate(chargeDirection * chargeSpeed * velocityModifier * Time.deltaTime, Space.World); // Move enemy towards player position
        }

        if (timer > chargingDelay && isCharging == true)
        {
            transform.Translate(chargeDirection * chargeSpeed * velocityModifier * Time.deltaTime, Space.World); // Uses the charge direction determined in the if statement above
        }

        timer += Time.deltaTime;
    }
}
