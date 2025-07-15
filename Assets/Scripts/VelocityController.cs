using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityController : MonoBehaviour
{
    public static VelocityController instance; // Using TimeController class as a Singleton so other scripts can easily acess the current velocity of the game

    public float velocityModifier = 1f;
    public Text velocityText;
    public GameObject cooldownBar;

    private Animator cooldownBarAnimator;
    private Slider timer;
    private bool slowmotionEnabled = true;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        cooldownBarAnimator = cooldownBar.GetComponent<Animator>();
        timer = cooldownBar.GetComponent<Slider>();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && slowmotionEnabled)
        {
            velocityModifier = 0.5f;
            velocityText.text = "0.5x";
            AudioController.instance.PlaySFX(5);

            cooldownBar.SetActive(true);
            cooldownBarAnimator.Play("Slowmotion");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            velocityModifier = 1f;
            velocityText.text = "1x";
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            velocityModifier = 1.5f;
            velocityText.text = "1.5x";
            AudioController.instance.PlaySFX(6);
        }

        if (timer.value == 0)
        {
            ResetVelocity();
            slowmotionEnabled = false;
        }
        if (!slowmotionEnabled && timer.value == 5)
        {
            slowmotionEnabled = true;
            cooldownBar.SetActive(false);
        }
    }

    public void ResetVelocity()
    {
        velocityModifier = 1f;
        velocityText.text = "1x";
        cooldownBarAnimator.Play("Cooldown");
    }
}
