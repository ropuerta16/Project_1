using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting_Scrp : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawner;
    private float CoolDown;
    public float Maxtime;

    void Awake()
    {
        CoolDown = Maxtime;
    }
    private void Update()
    {
        CoolDown -= Time.deltaTime;
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (CoolDown <= 0)
        { Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation); CoolDown = Maxtime; }
    }
}
