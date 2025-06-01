using UnityEngine;
using System.Collections;

public class SafeNet_Tutorial_2_scrp : MonoBehaviour
{
    public Transform Players;
    public GameObject SaveTxt;
    public GameObject ShootTxt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Players.transform.position = new Vector2(92f, 1.5f);
        StartCoroutine(ExecuteAfterDelay(5f));
    }


    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SaveTxt.SetActive(false);
        ShootTxt.SetActive(true);
    }
}
