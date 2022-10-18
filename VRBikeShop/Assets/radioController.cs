using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioController : MonoBehaviour
{
    private AudioSource Audio;
    
    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMute()
    {
        if (Audio.mute == false)
        {
            Audio.mute = true;
        }
        else
        {
            Audio.mute = false;
        }
    }
}
