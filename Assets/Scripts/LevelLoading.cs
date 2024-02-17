using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    [SerializeField] private Collider triggerCollider;
    public Animator transition;
    public float transitionTime = 1.5f;

    public Canvas canvas;
    public bool isTransitioning;
    
    //debug coroutine

    private void Start()
    {
        triggerCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadNextLevel(int levelIndex)
    {
        isTransitioning = true;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForEndOfFrame();
        canvas.renderMode = RenderMode.WorldSpace;
        isTransitioning = false;
    }
}
