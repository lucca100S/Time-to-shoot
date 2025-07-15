using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int health = 50;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealthController>().Heal(health);

            AudioController.instance.PlaySFX(4);
            Destroy(transform.parent.gameObject);  // Destroy health and shield powerup
        }
    }
}
