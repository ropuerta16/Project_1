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

    public TMP_Text counter;

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

        counter.text = currentBullet.ToString();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (coolDownShot <= 0 && currentBullet > 0)
        {

            if (player.linearVelocity.x < 0)
            {
                 GameObject Bullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                 BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                 BulletMovementComp.movementDirection = new Vector3(-1, 0, 0);
            }
            else
            {
                GameObject Bullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                BulletManager_scrp BulletMovementComp = Bullet.GetComponent<BulletManager_scrp>();

                BulletMovementComp.movementDirection = new Vector3(1, 0, 0);
            }

                coolDownShot = maxTimeCoolDown;
            currentBullet--;
        }
        else if (currentBullet <= 0)
        {
            if (coolDownReload <= 0)
            {
                currentBullet = maxBullet;
                counter.text = currentBullet.ToString();
                coolDownReload = 2f; 
            }
        }
    }
}
