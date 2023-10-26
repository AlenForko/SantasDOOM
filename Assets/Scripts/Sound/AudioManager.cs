using System;
using UnityEngine;

namespace Sound
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource effectsSource;
        public AudioSource musicSource;

        public static AudioManager Instance = null;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != null)
            {
                Destroy(gameObject);
            }
        }
        
        public void PlaySoundEffect(AudioClip clip)
        {
            effectsSource.clip = clip;
            effectsSource.Play();
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        public void Stop()
        {
            effectsSource.Stop();
            musicSource.Stop();
        }
    }
}
