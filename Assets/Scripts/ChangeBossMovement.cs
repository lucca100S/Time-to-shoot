using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ChangeBossMovement : MonoBehaviour
{
    private PathCreator path;

    private void Start()
    {
        path = GameObject.Find("PathBoss").GetComponent<PathCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= 9)
        {
            GetComponent<Move>().enabled = false; // Disables standard foward movement
            GetComponent<PathFollower>().enabled = true; // Change movement to horizontal motion
            GetComponent<PathFollower>().pathCreator = path;
            GetComponent<BossHealthController>().enabled = true; // Enemy is no longer invencible
        }
    }
}
