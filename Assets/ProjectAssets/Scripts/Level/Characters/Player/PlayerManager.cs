using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float jumpforce = 10f;
    float horizontalMovement;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;

    private Collider2D currentGroundCollider2D;

    private bool ActivePanel;

    public float Health;
    public float MaxHealth = 100f;

    public Animator animator;

    public Transform player;

    public Slider healthSlider;

    void Awake()
    {
        Health = MaxHealth;
        ActivePanel = false;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = Health;
    }
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);

        animator.SetFloat("XVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("YVelocity", rb.linearVelocity.y);
        
        if (rb.linearVelocity.x < 0)
        { player.localScale = new Vector3(-1, 1, 1); }
        else
        { player.localScale = new Vector3(1, 1, 1); }


    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
            SoundManager.instance.Jump_Audio.Play();
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    public void Esc(InputAction.CallbackContext context)
    {
        if (!ActivePanel)
        {
            HUDManager.instance.Panel_Menu.SetActive(true);
            Time.timeScale = 0;
            ActivePanel = true;
        }
        else if (ActivePanel)
        {
            HUDManager.instance.Panel_Menu.SetActive(false);
            Time.timeScale = 1;
            ActivePanel = false;
        }
    }


    private bool isGrounded()
    {
        Collider2D GroundCollider = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer);

        if (GroundCollider)
        {
            currentGroundCollider2D = GroundCollider;
            return true;
        }

        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy") )
        {
            Health -= 10; 
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Health -= 20;
        }

        healthSlider.value = Health;

        if (Health <= 0)
        { HUDManager.instance.GameOver(); }

    }

}
