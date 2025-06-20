using UnityEngine;

public class BasicEnemy_scrp : MonoBehaviour
{
    public float Health;

    private void Update()
    {
        if (Health <= 0)
        { Destroy(gameObject); }
        Debug.Log(Health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { Health -= 50; Destroy(collision.gameObject); }
    }
}
