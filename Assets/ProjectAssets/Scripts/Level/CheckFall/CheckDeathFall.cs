using UnityEngine;

public class CheckDeathFall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUDManager.instance.GameOver();
        }
    }
}
