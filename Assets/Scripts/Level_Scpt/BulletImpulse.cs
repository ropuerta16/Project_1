using UnityEngine;

public class BulletImpulse : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.zero;
    public float speed = 25f;
    void Update()
    {
        transform.position += movementDirection.normalized * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
