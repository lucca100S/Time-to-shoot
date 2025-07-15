using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            // Activate shield
            GameObject shield = col.transform.Find("Shield").gameObject;
            shield.SetActive(true);  
            col.gameObject.GetComponent<PlayerHealthController>().shielded = true;

            AudioController.instance.PlaySFX(4);
            Destroy(transform.parent.gameObject); // Destroy health and shield powerup
        }
    }
}
