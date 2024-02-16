using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrameInteractable : MonoBehaviour
{
    [SerializeField]
    private bool canInteract = false;

    private bool isInteracted = false;
    public GameObject frame;

    public GameObject dissolveObject; // Assign the object that need to change material
    public bool dissolveOut = true; // True for dissolve to transparent, false for solid
    public float dissolveSpeed = 0.5f;
    public Transform destination;
    public float movementSpeed = 1f;
    public float waitToDissolve = 2f;
    public bool finishPuzzle = false;

    private float targetDissolveValue;
    private float currentDissolveValue;

    void Start()
    {
        currentDissolveValue = dissolveOut ? -1f : 1f; // Start solid or transparent based on dissolveOut
    }

    void OnTriggerEnter(Collider other)
    {
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
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    isInteracted = true;
                }
            }
        }
    }

    void moveFrame()
    {
        //moving frame further and then start to dissolve
        Vector3 destinationPosition = destination.position;
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, movementSpeed * Time.deltaTime);

        Invoke("disableFrame", waitToDissolve);
    }

    void Update()
    {

        interact();
        

    }

    void disableFrame()
    {
        finishPuzzle = true;

        // Determine the target value based on the desired direction of the dissolve
        targetDissolveValue = dissolveOut ? 1f : -1f;

        // Update the dissolve value towards the target
        currentDissolveValue = Mathf.MoveTowards(currentDissolveValue, targetDissolveValue, dissolveSpeed * Time.deltaTime);

        // Apply the updated dissolve value to the material
        dissolveObject.GetComponent<Renderer>().material.SetFloat("_Dissolve_Time", currentDissolveValue);

        // Optionally, deactivate the object when fully dissolved
        if (dissolveOut && currentDissolveValue >= 0.45f)
        {
            frame.SetActive(false);
        }
    }
}
