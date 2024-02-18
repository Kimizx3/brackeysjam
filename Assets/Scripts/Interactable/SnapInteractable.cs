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



    private float targetDissolveValue;
    private float currentDissolveValue;

    void Start()
    {
        currentDissolveValue = dissolveOut ? -1f : 1f; // Start solid or transparent based on dissolveOut
    }

    // Update is called once per frame
    void Update()
    {
        if(drag.GetComponent<Drag>().isPlaced)
        {
            dissolveFrame();
            puzzleFinished = true;
        }
    }

    void dissolveFrame()
    {
        targetDissolveValue = dissolveOut ? 1f : -1f;

        // Update the dissolve value towards the target
        currentDissolveValue = Mathf.MoveTowards(currentDissolveValue, targetDissolveValue, dissolveSpeed * Time.deltaTime);

        // Apply the updated dissolve value to the material
        dissolveObject.GetComponent<Renderer>().material.SetFloat("_Dissolve_Time", currentDissolveValue);
        dissolveObject2.GetComponent<Renderer>().material.SetFloat("_Dissolve_Time", currentDissolveValue);

        // Optionally, deactivate the object when fully dissolved
        if (dissolveOut && currentDissolveValue >= 0.45f)
        {
            dissolveObject.SetActive(false);
        }
    }
}
