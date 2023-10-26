using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunAudioController : MonoBehaviour
{
    protected AudioSource audioSource;

    public AudioClip gunShootClip;
    public AudioClip outOfAmmoClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void ShootGun(float delay)
    {
        StartCoroutine(PlayClip(gunShootClip, delay));
    }

    public void OutOfAmmo(float delay)
    {
        StartCoroutine(PlayClip(outOfAmmoClip, delay));
    }

    public IEnumerator PlayClip(AudioClip clip, float wait)
    {
        yield return new WaitForSeconds(wait);
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
