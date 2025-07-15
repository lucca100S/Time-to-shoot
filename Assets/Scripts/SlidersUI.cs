using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersUI : MonoBehaviour
{
    public Text sliderText;
    public Slider slider;
    
    protected void UpdateSliderText(float value)
    {
        sliderText.text = (value * 100f).ToString("F0") + " %";
        slider.value = value;
    }
}
