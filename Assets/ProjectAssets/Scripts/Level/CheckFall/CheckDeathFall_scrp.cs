using UnityEngine;

public class CheckDeathFall_scrp : MonoBehaviour
{
    public GameObject GameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0.0f;
        GameOver.SetActive(true);
    }
}
