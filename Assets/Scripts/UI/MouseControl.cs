using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseControls : MonoBehaviour
{
    private Camera cam;
    public float raycastDistance = 10f;
    public Texture2D defaultText;
    public Texture2D clickableText;
    public Vector2 cursorSize = new Vector2(32, 32); // Adjust the cursor size here

    private void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor at the center of the screen
    }

    private void Update()
    {
        // Cast a ray forward from the center of the screen
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Object detected in front of the player
            // Debug.Log("Object detected: " + hit.collider.gameObject.name);

            // Check if the object is clickable
            Clickable clickable = hit.collider.GetComponent<Clickable>();
            if (clickable != null)
            {
                // Change cursor texture to clickableText
                Cursor.SetCursor(clickableText, new Vector2(cursorSize.x / 2, cursorSize.y / 2), CursorMode.Auto);
            }
            else
            {
                // Change cursor texture to defaultText
                Cursor.SetCursor(defaultText, new Vector2(cursorSize.x / 2, cursorSize.y / 2), CursorMode.Auto);
            }
        }
        else
        {
            // No object detected
            //Debug.Log("No object detected in front of the player.");

            // Change cursor texture to defaultText
            Cursor.SetCursor(defaultText, new Vector2(cursorSize.x / 2, cursorSize.y / 2), CursorMode.Auto);
        }

        // Lock the cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}

