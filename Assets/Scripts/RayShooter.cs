using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
     public GameObject quad; // Reference to the quad under the camera

    public float boxCastDistance = 10f; // Distance of the rectangle cast
    public Vector3 boxCastSize = new Vector3(1, 1, 1); // Size of the rectangle cast
    public LayerMask hitLayers; // Layer(s) the boxcast should hit

    private void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
    }

    private void Update()
    {
        PerformRectangleCast();
        // drag and drop function with raycasting
    }
    
    void PerformRectangleCast()
    {
        // Calculate the rectangle cast's direction
        Vector3 direction = cam.transform.forward;

        // Perform the rectangle cast from the camera's position
        RaycastHit[] hits = Physics.BoxCastAll(cam.transform.position, boxCastSize / 2, direction, cam.transform.rotation, boxCastDistance, hitLayers);

        bool targetHit = false; // Flag to check if the target object is hit

        // Iterate through all hits to check if the target object is among them
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("TargetTag")) // Replace "TargetTag" with the tag of the object you're interested in
            {
                // Target object is hit
                targetHit = true;
                break; // No need to check further
            }
        }

        // Disable or enable the quad based on whether the target object was hit
        if (targetHit)
        {
            // Disable the quad if it's not already disabled
            if (quad && quad.activeSelf)
                quad.SetActive(false);
        }
        else
        {
            // Enable the quad if it's not already enabled
            if (quad && !quad.activeSelf)
                quad.SetActive(true);
        }
    }

    // Draw Gizmos in the Scene View for debugging
    private void OnDrawGizmos()
    {
    if (cam == null)
    {
        cam = GetComponent<Camera>();
    }
    
    Gizmos.color = Color.red; // Set the color of the Gizmo

    // The center should be calculated based on the boxCastDistance and the starting point should be the camera's position
    Vector3 boxCastCenter = cam.transform.position + cam.transform.forward * (boxCastDistance / 2);
    
    // Since the rotation might also affect how the box is cast, especially if your camera can pitch up or down
    Gizmos.matrix = Matrix4x4.TRS(boxCastCenter, cam.transform.rotation, Vector3.one);

    // Now draw the wire cube with the correct center, rotation, and size
    Gizmos.DrawWireCube(Vector3.zero, boxCastSize); // Draw the wireframe box at the center adjusted by the Gizmos.matrix
    }
}
