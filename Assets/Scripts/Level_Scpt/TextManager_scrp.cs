using UnityEngine;
using System.Collections;
public class TextManager_scrp : MonoBehaviour
{
    public GameObject Welcome;
    public GameObject Problem;
    public GameObject KeyAD;
    void Start()
    {
        StartCoroutine(ExecuteAfterDelay(3f)); 
    }

    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Welcome.SetActive(false);
        Problem.SetActive(true);
        yield return new WaitForSeconds(delay);
        Problem.SetActive(false);
        KeyAD.SetActive(true);
    }

}
