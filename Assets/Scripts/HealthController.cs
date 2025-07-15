using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health;
    public float energy;

    public GameManager gameManager;
    public bool spawnPowerup;
    public bool endLevel1;
    public bool startBossBattle;

    public GameObject explosionEffect;
    protected float velocityModifier; // Game velocity set by the player. Used to modify damage and score

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        velocityModifier = VelocityController.instance.velocityModifier;
    }

    public void Damage(float damage)
    {
        Flash(); // Flashes gameObject with a red color

        health -= damage * velocityModifier;
        AudioController.instance.PlaySFX(1);

        // If health drops to zero, destroy the game object this script is attached to
        if (health <= 0)
        {
            float points = gameObject.GetComponent<EnemyCollision>().points;
            gameManager.Score(points);
            gameManager.FillRechargeBar(energy);

            if (spawnPowerup)
            {
                gameManager.SpawnPowerUp(transform.position);
            }

            if (endLevel1)
            {
                gameManager.TransitionToLevel2();
            }

            if (startBossBattle)
            {
                Debug.Log("Boss");
                startBossBattle = false; // Garantees the method will only be called once
                gameManager.StartBossBattle();
            }

            AudioController.instance.PlaySFX(3);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Heal(float heal)
    {
        health += heal; // Heals player or enemy

        // Limits health to 100
        if (health > 100)
        {
            health = 100;
        }
    }

    private void Flash()
    {
        foreach (Transform child in transform)
        {
            DamageFlash damageFlash = child.GetComponent<DamageFlash>();

            if (damageFlash != null)
            {
                child.gameObject.GetComponent<DamageFlash>().FlashStart();
            }
        }
    }
}
