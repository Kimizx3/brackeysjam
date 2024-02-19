using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [Header("footstep sounds")]
    public AudioClip carpet;
    public AudioClip woodfloor;
    public AudioSource audioSource;
    public string currentFloorTag = "Untagged";
    public bool isWalking = false;

    void Start()
    {
        
    }
    void Update()
    {
        bool isSwitch = SwitchFootstepSound();
        if(isWalking)
        {
            if(!(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)))
            {
                audioSource.Stop();
                isWalking = false;
            }
            else
            {
                if(isSwitch)
                {
                    audioSource.Stop();
                    audioSource.Play();
                }
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
            {
                
                audioSource.Play();
                isWalking = true;
            }
        }
    }

    private bool SwitchFootstepSound()
    {
        // Determine which footstep sound to play based on the tag of the floor the player is currently on
        switch (currentFloorTag)
        {
            case "Carpet":
                if(audioSource.clip == carpet)
                {
                    return false;
                }
                else
                {
                    audioSource.clip = carpet;
                    return true;
                }
            case "WoodFloor":
                if(audioSource.clip == woodfloor)
                {
                    return false;
                }
                else
                {
                    audioSource.clip = woodfloor;
                    return true;
                }
            default:
                // Optionally handle a default case or play a generic sound
                return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Update the current floor tag as the player moves over different floors
        currentFloorTag = other.tag;
    }
}
