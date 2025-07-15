using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Boundary")]
    public float horizontalBoundary;
    public float upperVerticalBoundary;
    public float lowerVerticalBoundary;

    [Header("Player Speed")]
    public float movementSpeed = 10;
    public float movementSmoothness = 5f;
    private float velocityModifier;

    public float angleTilt;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();

        velocityModifier = VelocityController.instance.velocityModifier; // Get velocity set by the player

        transform.Translate(direction * movementSpeed * velocityModifier * Time.deltaTime, Space.World);

        KeepPlayerInBounds();

        // Tilt ship
        horizontalInput = Input.GetAxis("Horizontal");

        float angle = -horizontalInput * angleTilt;
        float currentZ = transform.localEulerAngles.z;
        float newZ = Mathf.LerpAngle(currentZ, angle, movementSmoothness);
        transform.localEulerAngles = new Vector3(0f, 0f, newZ);
    }

    void KeepPlayerInBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > upperVerticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upperVerticalBoundary);
        }
        else if (transform.position.z < lowerVerticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerVerticalBoundary);
        }
    }
}
