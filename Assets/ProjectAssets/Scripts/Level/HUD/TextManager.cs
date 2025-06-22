using UnityEngine;
using System.Collections;
public class TextManager : MonoBehaviour
{
    public GameObject welcome;
    public GameObject problem;
    public GameObject keyAD;
    void Start()
    {
        StartCoroutine(ExecuteAfterDelay(3f)); 
    }

    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        welcome.SetActive(false);
        problem.SetActive(true);
        yield return new WaitForSeconds(delay);
        problem.SetActive(false);
        keyAD.SetActive(true);
    }

}
