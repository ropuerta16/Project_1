using UnityEngine;
using UnityEngine.InputSystem;
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

    public float Health;
    public float MaxHealth = 100f;

    public Animator animator;

    public Transform player;

    public Slider healthSlider;

    void Awake()
    {
        Health = MaxHealth;
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
            RecieveDamage(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            RecieveDamage(20);
        }
    }


    private void RecieveDamage(int damage)
    {
        Health -= damage;

        healthSlider.value = Health;

        if (Health <= 0)
        { HUDManager.instance.GameOver(); }
    }

}
