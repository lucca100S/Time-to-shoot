using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timer;
    public Gradient gradient;
    public Image fill;
    public Animator UIAnimator;

    private bool lowHealth = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.value -= Time.deltaTime;

        fill.color = gradient.Evaluate(timer.normalizedValue);

        // Trigger warning if health is bellow 20 seconds
        if (timer.value <= 20 && !lowHealth)
        {
            lowHealth = true;
            UIAnimator.Play("WarningPopup");
            UIAnimator.Play("WarningPanels");
            AudioController.instance.PlaySFX(8);
        } 
        else if (timer.value >= 20)
        {
            lowHealth = false;
            UIAnimator.Play("WarningDisabled", 0);
            UIAnimator.Play("WarningDisabled", 1);
        }
    }
}
