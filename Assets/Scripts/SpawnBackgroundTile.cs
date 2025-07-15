using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgroundTile : MonoBehaviour
{
    public GameObject backgroundTilePrefab;
    public Transform spawnPoint;
    public Transform tileParent;
    public float spawnRate = 1f;

    private float timer = 0f;
    private float velocityModifier;

    private void Start()
    {
        spawnPoint = GameObject.Find("TileSpawnPoint").transform;
        tileParent = GameObject.Find("Background").transform;
    }

    // Start is called before the first frame update
    void Update()
    {
        //velocityModifier = VelocityController.instance.velocityModifier;
        
        //if (timer >= spawnRate)
        //{
        //    Spawn();
        //}
        //timer += Time.deltaTime * velocityModifier;
    }

    void Spawn()
    {
        //Instantiate(backgroundTilePrefab, spawnPoint.position, spawnPoint.rotation, tileParent);
        //timer = 0f;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("TileSpawner"))
        {
            Instantiate(backgroundTilePrefab, spawnPoint.position, spawnPoint.rotation, tileParent);
        }
    }

}
