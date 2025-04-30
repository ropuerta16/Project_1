using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float force = 1f;
    public Check_ground Check_ground;
    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * force * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * force * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * force * Time.deltaTime;
        }
    }
}

