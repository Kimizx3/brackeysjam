using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Use Awake instead of Start for initialization to ensure
    // it's applied as soon as the GameObject is created.
    void Awake()
    {
        // This ensures that the GameObject that this script is attached to
        // isn't destroyed when loading a new scene.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here (if needed)
    }
}
