using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    private BoxCollider boxCollider;
    public GameObject puzzleComponent;

    public int newLayer;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.gameObject.GetComponent<BoxCollider>();
        boxCollider.enabled = false;
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
        if(puzzleComponent.GetComponent<FrameInteractable>().finishPuzzle)
        {
            Debug.Log("puzzle finished");
            //change layer of door
            ChangeLayerRecursive(gameObject, newLayer);
            //enable the colider
            boxCollider.enabled = true;
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
    void OnTriggerEnter(Collider other)
    {

    }
}
