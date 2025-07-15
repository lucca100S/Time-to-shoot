using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public int speed;
    public int damage = 50;
    public GameObject hitFX;

    private float velocityModifer;

    // Update is called once per frame
    void Update()
    {
        velocityModifer = VelocityController.instance.velocityModifier; // Get velocity set by the player

        transform.Translate(Vector3.forward * speed * velocityModifer * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        // If the bullet was shot by the player, damage an enemy
        if (CompareTag("PlayerBullet"))
        {
            if (col.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<HealthController>().Damage(damage); // Damages player or enemy
                Instantiate(hitFX, transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(gameObject); // Destroy bullet
            }
            else if (col.CompareTag("Boss"))
            {
                col.gameObject.GetComponent<BossHealthController>().Damage();
                Instantiate(hitFX, transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(gameObject); // Destroy bullet
            }
        }
        // If it was shot by an enemy, damage the player
        else if (CompareTag("EnemyBullet"))
        {
            if (col.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerHealthController>().Damage(damage); // Damages player or enemy
                Instantiate(hitFX, transform.position, Quaternion.identity);
                Destroy(gameObject); // Destroy bullet
            }
        }
    }
}
