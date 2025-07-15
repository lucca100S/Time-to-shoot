using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ChangeButteflyMovement : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= 1)
        {
            GetComponent<Move>().enabled = false; // Disables standard foward movement
            GetComponent<PathFollower>().enabled = true; // Change butterfly movement to horizontal motion
            GetComponent<HealthController>().enabled = true; // Enemy is no longer invencible
        }
    }
}
