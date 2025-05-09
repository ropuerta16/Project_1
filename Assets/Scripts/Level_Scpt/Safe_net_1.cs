using UnityEngine;
using System.Collections;

public class Safe_net_1 : MonoBehaviour
{
    public Transform Player;
    public GameObject Save;
    public GameObject Shoot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = new Vector2(92f, 1.5f);
        StartCoroutine(ExecuteAfterDelay(5f));
    }


    IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Save.SetActive(false);
        Shoot.SetActive(true);
    }
}
