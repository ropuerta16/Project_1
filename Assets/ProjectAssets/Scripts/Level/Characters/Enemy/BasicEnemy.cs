using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float maxHealth;

    private void Update()
    {
        if (maxHealth <= 0)
        { Destroy(gameObject); }
        Debug.Log(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { RecieveDamage(50); Destroy(collision.gameObject); }
    }

    private void RecieveDamage(int damage)
    {
        maxHealth -= damage;
    }
}
