using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.zero;
    public float speed = 25f;
    void Update()
    {
        transform.position += movementDirection.normalized * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))) 
        {
            Destroy(gameObject);
        }

    }
}
