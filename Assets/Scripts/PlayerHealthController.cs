using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : HealthController
{
    public bool shielded;
    public Slider timer;

    private void Start()
    {
        timer.maxValue = health;
        timer.value = health;
    }

    public new void Damage(float damage)
    {
        if (shielded)
        {
            shielded = false;
            GameObject shield = transform.Find("Shield").gameObject;
            shield.SetActive(false);
        }
        else
        {
            GetComponent<DamageFlash>().FlashStart(); // Flashes gameObject with a red color

            timer.value -= damage * velocityModifier;
            AudioController.instance.PlaySFX(2);
        }
    }

    public new void Heal(float heal)
    {
        timer.value += heal;
    }
}
