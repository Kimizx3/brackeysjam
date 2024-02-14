using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    [SerializeField]
    private bool canInteract = false;
    private GameObject frame;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
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
        if(canInteract)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                moveFrame();
            }
        }
    }

    void moveFrame()
    {
        
    }

}
