using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlayerManager_Scrp : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float jumpforce = 10f;
    float HorizontalMovement;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;

    public GameObject Panel_Menu;

    private Collider2D currentGroundCollider2D;

    private bool ActivePanel;

    public ButtonManager_scrp GameOver;

    public float Health;
    public float MaxHealth = 100f;

    public Animator animator;

    public Transform player;

    public Slider healthSlider;

    public AudioSource Jump_Audio;

    void Awake()
    {
        Health = MaxHealth;
        ActivePanel = false;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = Health;
    }
    void Update()
    {
        rb.linearVelocity = new Vector2(HorizontalMovement * speed, rb.linearVelocity.y);

        animator.SetFloat("XVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("YVelocity", rb.linearVelocity.y);
        
        if (rb.linearVelocity.x < 0)
        { player.localScale = new Vector3(-1, 1, 1); }
        else
        { player.localScale = new Vector3(1, 1, 1); }


    }

    public void Move(InputAction.CallbackContext context)
    {
        HorizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
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
            Jump_Audio.Play();
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
            Panel_Menu.SetActive(true);
            Time.timeScale = 0;
            ActivePanel = true;
        }
        else if (ActivePanel)
        {
            Panel_Menu.SetActive(false);
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
        { GameOver.GameOver(); }

    }

}
