using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Health = 100;
    public float CoolDown = 0.5f;

    public GameObject Bullet;

    public Vector2 Raydistance = new Vector2(50, 0);
    public GameObject Raypos;
    private void Update()
    {
        CoolDown -= Time.deltaTime;

        if (Health <= 0)
        { Destroy(gameObject); }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Raypos.transform.position.x, Raypos.transform.position.y), Raydistance);

#if UNITY_EDITOR
        Debug.DrawRay(new Vector2(Raypos.transform.position.x, Raypos.transform.position.y), Raydistance);
#endif
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            if (CoolDown <= 0)
            {
                Instantiate(Bullet, Raypos.transform.position, Raypos.transform.rotation);
                CoolDown = 0.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { Health -= 50; }
    }
}
