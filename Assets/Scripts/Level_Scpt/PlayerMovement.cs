using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float jumpforce = 10f;
    float HorizontalMovement;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f,0.5f);
    public LayerMask groundLayer;

    public GameObject Panel_Menu;
    public GameObject Panel_Background;

    private Collider2D currentGroundCollider2D;

    private bool ActivePanel;

    public GameObject Bullet;
    public GameObject BulletSpawner;
    void Awake()
    {
        ActivePanel = false;
    }
    void Update()
    {
        rb.linearVelocity = new Vector2 (HorizontalMovement * speed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        HorizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(isGrounded())
        {
            if (context.performed)
            {
                //Hold = full height
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            }
            else if (context.canceled)
            {
                //Press = low jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }
        
    }

    public void Esc(InputAction.CallbackContext context)
    {
        if(!ActivePanel)
        {
            Panel_Menu.SetActive(true);
            Panel_Background.SetActive(true);
            Time.timeScale = 0;
            ActivePanel = true;
        }
        else if (ActivePanel)
        {
            Panel_Menu.SetActive(false);
            Panel_Background.SetActive(false);
            Time.timeScale = 1;
            ActivePanel = false;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
    }
    private bool isGrounded()
    {
        Collider2D GroundCollider = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer);
        
        if(GroundCollider) 
        {
            currentGroundCollider2D = GroundCollider;
            return true; 
        } 
        
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position,groundCheckSize);
    }
}
