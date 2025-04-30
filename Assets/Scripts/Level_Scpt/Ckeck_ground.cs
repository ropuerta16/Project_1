using UnityEngine;

public class Ckeck_ground : MonoBehaviour
{
    public bool IsGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
    }

}
