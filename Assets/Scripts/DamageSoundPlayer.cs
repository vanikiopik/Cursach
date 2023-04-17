using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageSoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Player.HealthChanged += PlayHitSound;
    }


    void PlayHitSound(float value)
    {  
        _audioSource.Play();
    } 
}
