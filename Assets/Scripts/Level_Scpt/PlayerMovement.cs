using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidbody;
    public float jumpforce = 10f;
    float HorizontalMovement;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f,0.5f);
    public LayerMask groundLayer;

    private Collider2D currentGroundCollider2D;

    // Update is called once per frame
    void Update()
    {
        rigidbody.linearVelocity = new Vector2 (HorizontalMovement * speed, rigidbody.linearVelocity.y);
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
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpforce);
            }
            else if (context.canceled)
            {
                //Press = low jump
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, rigidbody.linearVelocity.y * 0.5f);
            }
        }
        
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
