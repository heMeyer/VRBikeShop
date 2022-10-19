using System.Collections;
using UnityEngine;

/// <summary>
/// Play a long continuous sound
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PlayContinuousSound : MonoBehaviour
{
    [Tooltip("The sound that is played")]
    public AudioClip sound = null;

    [Tooltip("The sound that is played when turning on")]
    public AudioClip turnOnSound = null;

    [Tooltip("Controls if the sound plays on start")]
    public bool playOnStart = false;

    [Tooltip("The volume of the sound")]
    public float volume = 1.0f;

    private AudioSource audioSource = null;
    private MonoBehaviour currentOwner = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    private void Start()
    {
        if (playOnStart)
            Play(sound);
    }

    public void Play(AudioClip clip)
    {
        if(clip == sound)
        {
            audioSource.clip = sound;
        }
        else if(clip == turnOnSound)
        {
            audioSource.clip = turnOnSound;
        }
        audioSource.Play();
    }

    public void Pause()
    {
        audioSource.clip = null;
        audioSource.Pause();
    }

    public void TogglePlay()
    {
        bool isPlaying = !IsPlaying();
        SetPlay(isPlaying);
    }

    public void SetPlay(bool playAudio)
    {
        if (playAudio)
        {
            Play(turnOnSound);
            wait();
            Play(sound);
        }
        else
        {
            Pause();
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void SetClip(AudioClip audioClip)
    {
        sound = audioClip;
    }

    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }
}
