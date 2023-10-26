using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayArmorPickUp()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
