using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitSoundController : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    public void HitSoundPlay()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
