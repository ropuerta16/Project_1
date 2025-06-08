using UnityEngine;

public class EnemyManager_scrp : MonoBehaviour
{
    public float health;
    private float coolDown;
    public float MaxCoolDown;

    public GameObject bullet;

    private Vector2 rayDistance = new Vector2(-1, 0);
    private Vector2 rayDistance_2 = new Vector2(1, 0);
    public float distance_1;
    public float distance_2;
    public GameObject raypos;
    public GameObject raypos_2;

    public Animator animator;

    public AudioSource bullet_Audio;

    private void Awake()
    {
        coolDown = MaxCoolDown;
    }
    private void Update()
    {
        coolDown -= Time.deltaTime;

        

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(raypos.transform.position.x, raypos.transform.position.y), rayDistance, distance_1);
        RaycastHit2D hit_2 = Physics2D.Raycast(new Vector2(raypos_2.transform.position.x, raypos_2.transform.position.y), rayDistance_2, distance_2);


#if UNITY_EDITOR
        Debug.DrawRay(new Vector2(raypos.transform.position.x, raypos.transform.position.y), rayDistance);
        Debug.DrawRay(new Vector2(raypos_2.transform.position.x, raypos_2.transform.position.y), rayDistance_2);
#endif
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") )
        {
            if (coolDown <= 0)
            {
                animator.SetTrigger("isAttacking_Enemy");
                
                bullet_Audio.Play();

                GameObject Bullet = Instantiate(bullet, raypos.transform.position, raypos.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(-1,0,0);
                
                coolDown = MaxCoolDown;
            }
        }

        if (hit_2.collider != null && hit_2.collider.gameObject.CompareTag("Player"))
        {
            if (coolDown <= 0)
            {
                animator.SetTrigger("isAttacking_Enemy");

                bullet_Audio.Play();

                GameObject Bullet = Instantiate(bullet, raypos_2.transform.position, raypos_2.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(1,0,0);

                coolDown = MaxCoolDown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { 
            health -= 50; 
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                animator.SetTrigger("isDead_Enemy");
            }
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
