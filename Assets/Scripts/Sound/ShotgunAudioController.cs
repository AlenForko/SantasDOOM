using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAudioController : GunAudioController
{
    public AudioClip reloadClip;

    public void ShotGunReloadSound(float delay)
    {
        StartCoroutine(PlayClip(reloadClip, delay));
    }
}
