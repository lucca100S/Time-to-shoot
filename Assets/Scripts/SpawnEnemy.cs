using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public PathCreator path;

    public bool spawnPowerUp = false;
    public bool endLevel1 = false;
    public bool startBossBattle = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("SpawnTrigger"))
        {
            // Spawns enemy and assign it's corresponding path

            GameObject enemy = Instantiate(enemyPrefab, gameObject.transform.position, enemyPrefab.transform.rotation);
            HealthController enemyHC = enemy.GetComponent<HealthController>();
            enemyHC.spawnPowerup = spawnPowerUp;
            enemyHC.endLevel1 = endLevel1;
            enemyHC.startBossBattle = startBossBattle;

            PathFollower pathFollower = enemy.GetComponent<PathFollower>();
            if (pathFollower != null)
            {
                pathFollower.pathCreator = path; // Assing path to spawned enemy
            }

            Destroy(gameObject); // Destroy spawner
        }
    }
}
