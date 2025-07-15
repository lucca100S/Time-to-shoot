using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimator : MonoBehaviour
{
    public void Disable()
    {
        GetComponent<Animator>().enabled = false;
    }
}
