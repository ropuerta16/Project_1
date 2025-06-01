using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerShooting_Scrp : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawner;
    private float CoolDownShot;
    public float MaxtimeCoolDown;
    public float MaxBullet = 10;
    private float currentBullet;
    private float CoolDownReload = 2f;

    public TMP_Text Counter;

    void Awake()
    {
        currentBullet = MaxBullet;
        CoolDownShot = MaxtimeCoolDown;
    }
    private void Update()
    {
        CoolDownShot -= Time.deltaTime;

        if (currentBullet <= 0)
        { CoolDownReload -= Time.deltaTime; }

        Counter.text = currentBullet.ToString();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (CoolDownShot <= 0 && currentBullet > 0)
        {
            Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
            CoolDownShot = MaxtimeCoolDown;
            currentBullet--;
        }
        else if (currentBullet <= 0)
        {
            if (CoolDownReload <= 0)
            {
                currentBullet = MaxBullet;
                CoolDownReload = 2f; 
            }
        }
    }
}
