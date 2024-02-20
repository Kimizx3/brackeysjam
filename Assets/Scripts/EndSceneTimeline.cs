using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class EndSceneTimeline : MonoBehaviour
{
    public PlayableDirector endSceneTimeLine;
    
    
    
    void Start()
    {
        endSceneTimeLine = GetComponent<PlayableDirector>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endSceneTimeLine.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endSceneTimeLine.Play();
        }
    }

    
}
