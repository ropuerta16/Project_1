using UnityEngine;

public class Cam_Follower : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform Camera;
    public Transform CamFollower;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float dist;

    private float z;
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        dist = Vector3.Distance(Camera.position, CamFollower.position);

        z = transform.position.z;
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / dist;

        // Set our position as a fraction of the distance between the markers.
        Vector3 newPosition = Vector3.Lerp(Camera.position, CamFollower.position, fractionOfJourney);

        // Apply the fixed Z position
        newPosition.z = z;

        // Update the transform position
        transform.position = newPosition;

    }
}
