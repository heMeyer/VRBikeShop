using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioController : MonoBehaviour
{
    private AudioSource audioSource = null;
    public AudioClip musicClip = null;
    public AudioClip switchClip = null;
    public float volume = 1.0f;
    public bool playOnStart = false;

    private float waitTime = 2.0f;
    private float musicClipTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = volume;
        waitTime = switchClip.length;
        if (playOnStart)
            Play(musicClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMute()
    {
        if (!audioSource.isPlaying)
        {
            StartCoroutine(SwitchOn());
        }
        else
        {
            StartCoroutine(SwitchOff());
        }
    }

    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;

        if (clip = musicClip)
        {
            audioSource.time = musicClipTime;
        }

        audioSource.Play();
    }

    public void Pause()
    {

    }

    IEnumerator SwitchOn()
    {
        Play(switchClip);
        yield return new WaitForSeconds(waitTime);
        Play(musicClip);
    }

    IEnumerator SwitchOff()
    {
        musicClipTime = audioSource.time;
        Play(switchClip);
        yield return new WaitForSeconds(waitTime);
        audioSource.clip = null;
        audioSource.Pause();
    }
}
