using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerShooting_Scrp : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawner;
    private float coolDownShot;
    public float maxTimeCoolDown;
    public float maxBullet = 10;
    private float currentBullet;
    private float coolDownReload = 2f;

    public Animator animator;

    public TMP_Text counter;

    public Rigidbody2D player;

    public AudioSource bullet_Audio;

    public GameObject Panel_Reloading;

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

        counter.text = currentBullet.ToString();


        if (coolDownReload <= 0)
        {
            Panel_Reloading.SetActive(false);
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

            if (player.linearVelocity.x < 0)
            {
                bullet_Audio.Play();

                GameObject Bullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(-1, 0, 0);
            }
            else
            {
                bullet_Audio.Play();

                GameObject Bullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(1, 0, 0);
            }

            coolDownShot = maxTimeCoolDown;
            currentBullet--;
        }
        else if (currentBullet <= 0)
        {
            Panel_Reloading.SetActive(true);
        }
    }
}
