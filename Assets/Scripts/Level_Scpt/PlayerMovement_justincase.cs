using UnityEngine;

public class PlayerMovement_justincase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float movespeed = 10f;
    public float jumpforce = 100f;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A and D


        Vector2 horizontalforce = new Vector2(horizontal * movespeed, 0);

        rb.AddForce(horizontalforce);


        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            float vertical = Input.GetAxis("Vertical"); // W and S

            Vector2 verticalforce = new Vector2(0, vertical * jumpforce);

            rb.AddForce(verticalforce);
        }
    }
    private bool isGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        { return true; }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
    }
}
