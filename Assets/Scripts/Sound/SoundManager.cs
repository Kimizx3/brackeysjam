using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    [Header("Sound List")]
    public AudioClip doorSound;
    public AudioClip magicAppearing;
    
    [Header("AudioPlayer")]
    public AudioSource audioSource;

    public void playerDoorSound()
    {
        audioSource.clip = doorSound;
        audioSource.Play();
    }

    public void playerMagicAppearingSound()
    {
        audioSource.clip = magicAppearing;
        audioSource.Play();
    }
}
