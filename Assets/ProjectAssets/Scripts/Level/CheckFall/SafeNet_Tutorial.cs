using UnityEngine;

public class SafeNet_Tutorial : MonoBehaviour
{
    public Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector2(35f, 1.5f);
    }
}
