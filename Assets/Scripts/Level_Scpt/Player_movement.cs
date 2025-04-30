using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float force = 1f;
    Rigidbody2D rigidbody;
    float time = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.W) && time <= 0)
        {
            Vector3 movement = new Vector3(0, 10, 0);

            rigidbody.AddForce(movement * (force * 1000) * Time.deltaTime);
            time = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(-1, 0, 0);

            rigidbody.AddForce(movement * (force * 250) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(1, 0, 0);

            rigidbody.AddForce(movement * (force * 250) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movement = new Vector3(0, -1, 0);

            rigidbody.AddForce(movement * (force * 1000) * Time.deltaTime);
        }
    }
}

