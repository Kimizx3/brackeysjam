using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMenu : MonoBehaviour
{
    LevelLoading _levelLoading;
    void Start()
    {
        _levelLoading = GetComponent<LevelLoading> ();
        _levelLoading.LoadLevel();
    }
}
