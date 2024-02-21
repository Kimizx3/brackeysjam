using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    
    public GameObject puzzleComponent;
    public GameObject fakeWall;

    public GameObject interactableDoor;
    public GameObject WallQuad;

    public int newLayer;
    // Start is called before the first frame update
    void Start()
    {
        interactableDoor.GetComponent<DoorOpenDevice>().enabled = false;
        // Initialize newLayer
        newLayer = LayerMask.NameToLayer("Default");
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIfPuzzleFinished();
    }

    void checkIfPuzzleFinished()
    {
        if(puzzleComponent.GetComponent<FrameInteractable>() != null)
        {
            if(puzzleComponent.GetComponent<FrameInteractable>().finishPuzzle)
            {
                //change layer of door
                ChangeLayerRecursive(gameObject, newLayer);
                // disable the wall
                fakeWall.SetActive(false);
                //enable the interable script
                interactableDoor.GetComponent<DoorOpenDevice>().enabled = true;
                
            }
        }
        else if(puzzleComponent.GetComponent<SnapInteractable>() != null)
        {
            if(puzzleComponent.GetComponent<SnapInteractable>().puzzleFinished)
            {
                //change layer of door
                ChangeLayerRecursive(gameObject, newLayer);
                // disable the wall
                WallQuad.SetActive(false);
                fakeWall.SetActive(false);
                //enable the interable script
                interactableDoor.GetComponent<DoorOpenDevice>().enabled = true;
                
            }
        }
        
    }

    void ChangeLayerRecursive(GameObject gameObject, int newLayer)
    {
        gameObject.layer = newLayer;
        
        foreach (Transform child in gameObject.transform)
        {
            ChangeLayerRecursive(child.gameObject, newLayer);
        }
    }
}
