using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSFX : SlidersUI
{
    private void Awake()
    {
        UpdateVolumeSFX(AudioController.instance.GetVolumeSFX());
    }

    public void UpdateVolumeSFX(float value)
    {
        UpdateSliderText(value);
        AudioController.instance.UpdateVolumeSFX(value);
    }
}
