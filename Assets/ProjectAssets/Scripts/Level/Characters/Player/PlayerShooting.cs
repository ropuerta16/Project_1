using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawner;
    private float coolDownShot;
    public float maxTimeCoolDown;
    public float maxBullet = 10;
    private float currentBullet;
    private float coolDownReload = 2f;

    public Animator animator;

    public Rigidbody2D player;

    void Awake()
    {
        currentBullet = maxBullet;
        coolDownShot = maxTimeCoolDown;
    }
    private void Update()
    {
        coolDownShot -= Time.deltaTime;

        if (currentBullet <= 0)
        { coolDownReload -= Time.deltaTime; }

        HUDManager.instance.counter.text = currentBullet.ToString();
        

        if (coolDownReload <= 0)
        {
            HUDManager.instance.Panel_Reloading.SetActive(false);
            currentBullet = maxBullet;
            coolDownReload = 2f;
        }


    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (!gameObject.activeSelf)
        { return; }

        if (coolDownShot <= 0 && currentBullet > 0)
        {
            animator.SetTrigger("isAttacking");

            GameObject Bullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            BulletManager BulletMovementComp = Bullet.GetComponent<BulletManager>();

            if (player.linearVelocity.x < 0)
            {
                BulletMovementComp.movementDirection = new Vector3(-1, 0, 0);
            }
            else
            {
                BulletMovementComp.movementDirection = new Vector3(1, 0, 0);
            }

            SoundManager.instance.bullet_Audio.Play();

            coolDownShot = maxTimeCoolDown;
            currentBullet--;
        }
        else if (currentBullet <= 0)
        {
            HUDManager.instance.Panel_Reloading.SetActive(true);
        }
    }
}
