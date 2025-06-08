using UnityEngine;

public class CheckDeathFall_scrp : MonoBehaviour
{
    public ButtonManager_scrp Manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager.GameOver();
        }
    }
}
