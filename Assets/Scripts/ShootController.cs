using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] bulletSpawnPoints;

    public float fireRate;
    protected float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Shoots every fireRate seconds
        if (timer > fireRate)
        {
            Shoot();
        }
        timer += Time.deltaTime;
    }

    protected void Shoot()
    {
        timer = 0f;

        foreach (Transform spawnPoint in bulletSpawnPoints)
        {
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
