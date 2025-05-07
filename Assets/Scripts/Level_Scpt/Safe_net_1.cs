using UnityEngine;

public class Safe_net_1 : MonoBehaviour
{
    public Transform Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = new Vector2(92f, 1.5f);
    }
}
