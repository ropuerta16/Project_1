using TreeEditor;
using UnityEngine;

public class BulletImpulse : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(transform.position.x + 1f,transform.position.y,transform.position.z);
    }
}
