using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVSlider : MonoBehaviour
{
    public Slider slide;

    public void SaveFOV(float value)
    {
        PlayerPrefs.SetFloat("FOV", value);
    }
    private void Start()
    {
        slide.value = PlayerPrefs.GetFloat("FOV");
    }
}
