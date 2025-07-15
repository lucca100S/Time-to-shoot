using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : ShootController
{
    
    void Update()
    {
        // The bullet is shot upon player input
        if (Input.GetKey(KeyCode.J) && timer > fireRate)
        {
            Shoot();
            AudioController.instance.PlaySFX(1);
        }
        timer += Time.deltaTime;
    }
}
