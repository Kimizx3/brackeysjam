using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameInteractable : MonoBehaviour
{
    [SerializeField]
    private bool canInteract = false;

    private bool isInteracted = false;
    public GameObject frame;

    public GameObject dissolveObject; // Assign this in the Inspector
    public bool dissolveOut = true; // True for dissolve to transparent, false for solid
    public float dissolveSpeed = 0.5f;

    private float targetDissolveValue;
    private float currentDissolveValue;

    void Start()
    {
        currentDissolveValue = dissolveOut ? -1f : 1f; // Start solid or transparent based on dissolveOut
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Player")
        {
            canInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            canInteract = false;
        }
    }

    void interact()
    {
        if(isInteracted)
        {
            moveFrame();
        }
        else
        {
            if(canInteract)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    // Debug.Log("EEEEE");
                    isInteracted = true;
                }
            }
        }
    }

    void moveFrame()
    {
        
        disableFrame();
    }

    void Update()
    {

        interact();
        // disableFrame();

    }

    void disableFrame()
    {
        // Determine the target value based on the desired direction of the dissolve
        targetDissolveValue = dissolveOut ? 1f : -1f;

        // Update the dissolve value towards the target
        currentDissolveValue = Mathf.MoveTowards(currentDissolveValue, targetDissolveValue, dissolveSpeed * Time.deltaTime);
        Debug.Log(currentDissolveValue);
        // Apply the updated dissolve value to the material
        // dissolveMaterial.SetFloat("_DissolveAmount", currentDissolveValue);
        dissolveObject.GetComponent<Renderer>().material.SetFloat("_Dissolve_Time", currentDissolveValue);

        // Optionally, deactivate the object when fully dissolved
        if (dissolveOut && currentDissolveValue >= 0.5f)
        {
            frame.SetActive(false);
        }
    }
}
