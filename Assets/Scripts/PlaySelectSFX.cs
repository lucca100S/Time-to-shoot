using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySelectSFX : MonoBehaviour
{
    public void PlaySFX()
    {
        AudioController.instance.PlaySFX(0);
    }
}
