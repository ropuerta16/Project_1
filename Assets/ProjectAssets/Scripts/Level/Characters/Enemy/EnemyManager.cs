using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float maxHealth;
    private float coolDown;
    public float maxCoolDown;

    public GameObject bullet;

    private Vector2 rayDistance = new Vector2(-1, 0);
    private Vector2 rayDistance_2 = new Vector2(1, 0);
    public float distance_1;
    public float distance_2;
    public GameObject raypos_1;
    public GameObject raypos_2;

    public Animator animator;

    

    private void Awake()
    {
        coolDown = maxCoolDown;
    }
    private void Update()
    {
        coolDown -= Time.deltaTime;

        GameObject raypos = CheckRayCollision();

        if (raypos != null)
        {
            Shoot(raypos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            RecieveDamage(50);
            Destroy(collision.gameObject);
        }
    }

    private void RecieveDamage(int damage)
    {
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            animator.SetTrigger("isDead_Enemy");
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private GameObject CheckRayCollision()
    {

#if UNITY_EDITOR
        Debug.DrawRay(new Vector2(raypos_1.transform.position.x, raypos_1.transform.position.y), rayDistance);
        Debug.DrawRay(new Vector2(raypos_2.transform.position.x, raypos_2.transform.position.y), rayDistance_2);
#endif
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(raypos_1.transform.position.x, raypos_1.transform.position.y), rayDistance, distance_1);
        RaycastHit2D hit_2 = Physics2D.Raycast(new Vector2(raypos_2.transform.position.x, raypos_2.transform.position.y), rayDistance_2, distance_2);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        { return raypos_1; }
        else if (hit_2.collider != null && hit_2.collider.gameObject.CompareTag("Player"))
        { return raypos_2; }
        else
        { return null; }
    }

    private void Shoot(GameObject raypos)
    {
        if (coolDown <= 0)
        {
            animator.SetTrigger("isAttacking_Enemy");

            SoundManager.instance.bullet_Audio.Play();

            GameObject Bullet = Instantiate(bullet, raypos.transform.position, raypos.transform.rotation);
            BulletManager BulletMovementComp = Bullet.GetComponent<BulletManager>();

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector3 direction = player.transform.position - raypos.transform.position;

            direction.y = 0; direction.z = 0;
            direction = Vector3.Normalize(direction);

            BulletMovementComp.movementDirection = direction;

            coolDown = maxCoolDown;
        }
    }
}
