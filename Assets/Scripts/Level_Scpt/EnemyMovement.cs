using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Health = 100;
    public float CoolDown = 0.5f;

    public GameObject Bullet;

    private Vector2 Raydistance = new Vector2(-1, 0);
    public float distance;
    public GameObject Raypos;
    private void Update()
    {
        CoolDown -= Time.deltaTime;

        if (Health <= 0)
        { Destroy(gameObject); }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Raypos.transform.position.x, Raypos.transform.position.y), Raydistance, distance);

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
