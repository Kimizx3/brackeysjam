using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.volume = 0.2f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.volume = 0;
        }
    }
}
