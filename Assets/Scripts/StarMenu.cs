using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMenu : MonoBehaviour
{
    public GameObject _levelLoading;
    
    public void StartGame()
    {
        _levelLoading.GetComponent<LevelLoading>().LoadLevel();
    }
}
