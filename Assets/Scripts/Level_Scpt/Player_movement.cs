using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float force = 1f;
    public Rigidbody2D rigidbody;

    public Check_ground Check_ground;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Check_ground.IsGrounded)
        {
            Vector2 movement = new Vector2(0, 10);

            rigidbody.AddForce(movement * (force * 1000) * Time.deltaTime);

            Check_ground.IsGrounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector2 movement = new Vector2(-10, 0);

            rigidbody.AddForce(movement * (force * 1000) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector2 movement = new Vector2(10, 0);

            rigidbody.AddForce(movement * (force * 1000) * Time.deltaTime);
        }

        /*
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 movement = new Vector2(0, -1);

            rigidbody.AddForce(movement * (force * 1000) * Time.deltaTime);
        }*/
    }
}

