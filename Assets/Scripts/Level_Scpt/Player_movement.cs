using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float force;
    public float speed;
    private Rigidbody2D rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    public Transform groundPosition;

    public Vector2 direction = Vector2.zero;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
        {
            transform.localPosition = new Vector3(-1f, 1f, 1f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localPosition = new Vector3 (1f, 1f, 1f);
        }

        Debug.DrawRay(groundPosition.position, Vector3.down * 0.4f, Color.red);

        if (Physics2D.Raycast(groundPosition.position, Vector3.down, 0.4f))
        { Grounded = true; }
        else { Grounded = false; }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        { Jump(); }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * force);
    }
    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(Horizontal * speed, rigidbody2D.linearVelocityY);
    }
}

