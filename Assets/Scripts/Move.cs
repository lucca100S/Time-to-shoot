using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    private float velocityModifier;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3 (horizontalSpeed, 0, verticalSpeed);

        velocityModifier = VelocityController.instance.velocityModifier; // Get velocity set by the player

        transform.Translate(direction * velocityModifier * Time.deltaTime, Space.World);
    }
}
