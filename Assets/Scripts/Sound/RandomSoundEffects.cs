using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundEffects : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    public float interval;
    float currentInterval;
    // Start is called before the first frame update
    void Start()
    {
        currentInterval = interval;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInterval < 0)
        {
            if (!audioSource.isPlaying)
            {
                currentInterval = interval;
                audioSource.clip = clips[Random.Range(0, clips.Length)];
                audioSource.Play();
            }
        }
        currentInterval -= Time.deltaTime;
    }
}
