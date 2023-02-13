using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    GameObject volumeSlider;
    public Slider sliderInstance;
    // Start is called before the first frame update
    void Start()
    {
        sliderInstance.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
