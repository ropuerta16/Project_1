using UnityEngine;

public class CamFollower_scrp : MonoBehaviour
{
    public Transform Camera;
    public Transform CamFollower;
    public float speed = 0.07f;
    private float startTime;
    private float dist;

    private float z;
    void Start()
    {
        startTime = Time.time;

        dist = Vector3.Distance(Camera.position, CamFollower.position);

        z = transform.position.z;
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / dist;
        Vector3 newPosition = Vector3.Lerp(Camera.position, CamFollower.position, fractionOfJourney);
        newPosition.z = z;

        transform.position = newPosition;

    }
}
