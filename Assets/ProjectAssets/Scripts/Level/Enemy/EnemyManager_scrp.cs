using UnityEngine;

public class EnemyManager_scrp : MonoBehaviour
{
    public float health = 100;
    public float coolDown = 1f;

    public GameObject bullet;

    private Vector2 rayDistance = new Vector2(-1, 0);
    private Vector2 rayDistance_2 = new Vector2(1, 0);
    public float distance;
    public GameObject raypos;
    public GameObject raypos_2;

    private void Update()
    {
        coolDown -= Time.deltaTime;

        if (health <= 0)
        { Destroy(gameObject); }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(raypos.transform.position.x, raypos.transform.position.y), rayDistance, distance);
        RaycastHit2D hit_2 = Physics2D.Raycast(new Vector2(raypos_2.transform.position.x, raypos_2.transform.position.y), rayDistance_2, distance);


#if UNITY_EDITOR
        Debug.DrawRay(new Vector2(raypos.transform.position.x, raypos.transform.position.y), rayDistance);
        Debug.DrawRay(new Vector2(raypos_2.transform.position.x, raypos_2.transform.position.y), rayDistance_2);
#endif
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") )
        {
            if (coolDown <= 0)
            {
                GameObject Bullet = Instantiate(bullet, raypos.transform.position, raypos.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(1,1,1);

                coolDown = 0.5f;
            }
        }

        if (hit_2.collider != null && hit_2.collider.gameObject.CompareTag("Player"))
        {
            if (coolDown <= 0)
            {
                GameObject Bullet = Instantiate(bullet, raypos_2.transform.position, raypos_2.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(-1,1,1);

                coolDown = 0.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { health -= 50; }
    }
}
