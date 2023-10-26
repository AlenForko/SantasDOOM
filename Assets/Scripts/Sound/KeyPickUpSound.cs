using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpSound : MonoBehaviour
{
   private AudioSource _audioSource;

   private void Start()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   public void PickUpSoundPlay()
   {
      if (!_audioSource.isPlaying)
      {
         _audioSource.Play();
      }
   }
}
