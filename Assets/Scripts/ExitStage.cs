using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStage : MonoBehaviour
{
    public float initialSpeed;
    public float acceleration;

    private void Update()
    {
        float speed = initialSpeed + acceleration * Time.deltaTime; // Calculates speed considering an accelerated motion
        initialSpeed = speed; // Saves current speed for next frame
        
        transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }
}