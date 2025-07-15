using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 5;
    public float points = 100;

    private void OnTriggerEnter(Collider col)
    {
        // If the player collides with the enemy, kill the enemy and damage player
        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<HealthController>().Damage(100); // Enemy takes 100 damage in order to get detroyed immediately
            col.gameObject.GetComponent<PlayerHealthController>().Damage(damage); // Damages player
        }
    }
}
