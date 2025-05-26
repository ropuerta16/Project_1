using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
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

    public Button_Manager GameOver;

    public float Health = 100f;

    public SpriteRenderer spr1;
    public SpriteRenderer spr2;

    public Sprite sp0;
    public Sprite sp10;
    public Sprite sp20;
    public Sprite sp30;
    public Sprite sp40;
    public Sprite sp50;

    public Animator animator;

    void Awake()
    {
        ActivePanel = false;
    }
    void Update()
    {
        rb.linearVelocity = new Vector2(HorizontalMovement * speed, rb.linearVelocity.y);

        animator.SetFloat("XVelocity",Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("YVelocity",rb.linearVelocity.y);

        if (Health <= 0)
        { GameOver.GamneOver(); }
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
        if (collision.gameObject.CompareTag("Bullet"))
        { Health -= 10; Sprite(); }
    }

    private void Sprite()
    {
        switch (Health)
        {
            case 0:
                spr1.sprite = sp0;
                break;
            case 10:
                spr1.sprite = sp10;
                break;
            case 20:
                spr1.sprite = sp20;
                break;
            case 30:
                spr1.sprite = sp30;
                break;
            case 40:
                spr1.sprite = sp40;
                break;
            case 50:
                spr2.sprite = sp0;
                break;
            case 60:
                spr2.sprite = sp10;
                break;
            case 70:
                spr2.sprite = sp20;
                break;
            case 80:
                spr2.sprite = sp30;
                break;
            case 90:
                spr2.sprite = sp40;
                break;
            case 100:
                spr2.sprite = sp50;
                break;
        }
    }
}
