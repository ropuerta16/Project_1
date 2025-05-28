using UnityEngine;

public class BasicEnemy_scrp : MonoBehaviour
{
    public float Health = 100;

    private void Update()
    {
        if (Health <= 0)
        { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { Health -= 50; }
    }
}
