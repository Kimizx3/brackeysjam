using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.5f;

    public Canvas canvas;
    private bool isTransitioning;

    

    public void LoadLevel()
    {
        StartCoroutine(LoadNextLevelCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadNextLevelCoroutine(int levelIndex)
    {
        isTransitioning = true;
        transition.SetTrigger("Start");

        // Wait for the transition animation to complete
        yield return new WaitForSeconds(transitionTime);

        // Load the scene asynchronously
        SceneManager.LoadScene(levelIndex);

        // Ensure the scene is fully loaded before changing the Canvas render mode
        yield return new WaitForEndOfFrame();
        isTransitioning = false;
    }
}