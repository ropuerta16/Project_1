using UnityEngine;

public class Check_ground : MonoBehaviour
{
    public bool IsGrounded = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
    }
}
