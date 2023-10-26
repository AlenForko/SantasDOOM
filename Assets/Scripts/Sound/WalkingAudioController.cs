using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WalkingAudioController : MonoBehaviour
{
    public float soundActiveFor = 0.2f;
    private AudioSource audioSource;
    float currentSoundActive;
    private void Start()
    {
        currentSoundActive = soundActiveFor;
        audioSource = GetComponent<AudioSource>();
    }

    public void Walking(float walkingSpeed)
    {
        if(walkingSpeed > 0 && !audioSource.isPlaying)
        {
            if (currentSoundActive < 0)
            {
                audioSource.Play();
                currentSoundActive = soundActiveFor;
            }

        }
        else if(walkingSpeed <= 0)
        {
            audioSource.Stop();
        }
        currentSoundActive -= Time.fixedDeltaTime;
        if (currentSoundActive < 0)
        {
            audioSource.Stop();
        }
    }
}
