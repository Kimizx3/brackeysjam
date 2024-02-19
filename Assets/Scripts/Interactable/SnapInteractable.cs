using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapInteractable : MonoBehaviour
{
    
    public bool puzzleFinished = false;

    public GameObject dissolveObject;
    public GameObject dissolveObject2;
    public GameObject drag;
    public bool dissolveOut = true; // True for dissolve to transparent, false for solid
    public float dissolveSpeed = 0.5f;
    public float movementSpeed = 1f;
    public float waitToDissolve = 2f;
    public GameObject sfx;
    public bool dissolved = false;



    private float targetDissolveValue;
    private float currentDissolveValue;

    void Start()
    {
        currentDissolveValue = dissolveOut ? -1f : 1f; // Start solid or transparent based on dissolveOut
    }

    // Update is called once per frame
    void Update()
    {
        if(!dissolved && drag.GetComponent<Drag>().isPlaced)
        {
            
            StartCoroutine(DissolveEffect());
            puzzleFinished = true;
                
        }
        
    }

    IEnumerator DissolveEffect()
    {
        //play the magic sound effect
        sfx.GetComponent<SoundManager>().playerMagicAppearingSound();
        
        targetDissolveValue = dissolveOut ? 1f : -1f;

        while (Mathf.Abs(currentDissolveValue - targetDissolveValue) > Mathf.Epsilon)
        {
            currentDissolveValue = Mathf.MoveTowards(currentDissolveValue, targetDissolveValue, dissolveSpeed * Time.deltaTime);
            dissolveObject.GetComponent<Renderer>().material.SetFloat("_Dissolve_Time", currentDissolveValue);
            dissolveObject2.GetComponent<Renderer>().material.SetFloat("_Dissolve_Time", currentDissolveValue);
            yield return null; // Wait for the next frame
        }

        if (dissolveOut && currentDissolveValue >= 0.45f)
        {
            dissolveObject.SetActive(false);
        }

        dissolved = true;
    }
}
