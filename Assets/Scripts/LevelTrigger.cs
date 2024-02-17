using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    private LevelLoading _levelLoading;
    

    // Start is called before the first frame update
    void Start()
    {
        _levelLoading = GetComponent<LevelLoading>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _levelLoading.LoadLevel();
        }
    }
}
    
