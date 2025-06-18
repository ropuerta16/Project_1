using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform camera;
    public Transform camFollower;
    public float speed = 0.07f;
    private float startTime;
    private float dist;

    private float z;
    void Start()
    {
        startTime = Time.time;

        dist = Vector3.Distance(camera.position, camFollower.position);

        z = transform.position.z;
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / dist;
        Vector3 newPosition = Vector3.Lerp(camera.position, camFollower.position, fractionOfJourney);
        newPosition.z = z;

        transform.position = newPosition;

    }
}
