using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingManager_scrp : MonoBehaviour
{
    public static string newScene;
    void Start()
    {

        StartCoroutine(ExecuteAfterDelay(5f)); 
    }

    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newScene);
    }
}
