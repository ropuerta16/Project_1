using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUDManager.instance.Victory();
        }

    }
}
