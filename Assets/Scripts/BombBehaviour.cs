using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float upperLimit = 6f;
    public float lowerLimit = -5f;
    
    public GameObject bulletPrefab;

    private GameObject player;
    private float explodePosition;

    private void Start()
    {
        player = GameObject.Find("Player");
        explodePosition = Random.Range(-5f, 6f); // Limits based of player movement limit
    }

    private void Update()
    {
        if (transform.position.z <= explodePosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (GetComponent<HealthController>() != null)
        {
            GameObject explosionEffect = GetComponent<HealthController>().explosionEffect;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
            
        AudioController.instance.PlaySFX(3);
        
        // Quando a bomba e destruida, atira tiros em um padrao circular

        Vector3 rotation = Vector3.zero; // Variavel que determina a rotacao dos tiros a serem criados

        // Criacao de 8 tiros
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(rotation));
            rotation += new Vector3(0f, 45f, 0f); // Rotaciona em 45 graus no eixo y
        }
    }
}
