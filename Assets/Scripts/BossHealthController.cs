using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour
{
    public float health;
    public Slider healthBar;
    public GameManager gameManager;
    public GameObject explosionEffect;
    public Transform[] explosionPoints;

    private bool alive = true;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthBar = GameObject.Find("BossHealthBar").GetComponent<Slider>(); // Armazena a barra de vida do Boss
        
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void Damage()
    {
        Flash(); // Flashes gameObject with a red color

        health--;
        if (healthBar != null)
        {
            healthBar.value = health;
        }
        AudioController.instance.PlaySFX(1);

        // Se a vida fica abaixo de zero, destroi o Boss
        if (health <= 0 && alive)
        {
            alive = false;
            gameManager.ClearBullets();
            gameManager.Score(10000);

            StartCoroutine(ChainedExplosion());
            //gameManager.Win();
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

    IEnumerator ChainedExplosion()
    {
        gameObject.GetComponent<PathFollower>().enabled = false; // Deactivates movement
        gameObject.GetComponent<ShootController>().enabled = false; // Deactivates shooting
        
        for (int i = 0; i < explosionPoints.Length; i++)
        {
            AudioController.instance.PlaySFX(3);
            GameObject explosion = Instantiate(explosionEffect, explosionPoints[i]);
            int rand = Random.Range(1, 4);
            explosion.transform.localScale = Vector3.one * rand;

            Flash();
            yield return new WaitForSeconds(0.3f);
        }
        DisableMeshRenderer();

        yield return new WaitForSeconds(1);
        gameManager.Win();
        Debug.Log("Win");
        


        yield return null;
    }

    void DisableMeshRenderer()
    {
        // Disable all child's mesh renderers

        foreach (Transform child in transform)
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }
    }

}
