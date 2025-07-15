using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject powerupPrefab;
    private Vector3 currentPosition;

    public void Update()
    {
        // Get last position before destruction
        if (transform != null)
        {
            currentPosition = transform.position;
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Destruido");
        Instantiate(powerupPrefab, currentPosition, Quaternion.identity);
    }
}
