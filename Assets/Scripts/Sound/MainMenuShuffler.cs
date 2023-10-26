using UnityEngine;

namespace Sound
{
    public class MainMenuShuffler : MonoBehaviour
    {
        public AudioSource audioSource;

        public AudioClip[] clip;

        private void Awake()
        {
            audioSource.clip = clip[Random.Range(0, clip.Length)];
            audioSource.Play();
        }
    }
}
