using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBGMusic : SlidersUI
{
    private void Awake()
    {
        UpdateVolumeBGMusic(AudioController.instance.GetVolumeBG());
    }

    public void UpdateVolumeBGMusic(float value)
    {
        UpdateSliderText(value);
        AudioController.instance.UpdateVolumeBG(value);
    }
}
