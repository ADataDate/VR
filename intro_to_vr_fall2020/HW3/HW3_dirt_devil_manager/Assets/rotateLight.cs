// At play time, the script will move the object along a path between the position of those two markers.

using UnityEngine;
using System.Collections;

public class rotateLight : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Vector3 initialRotation;
    public Vector3 finalRotation;

    // Movement speed in units per second.
    public float speed = 0.5F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(initialRotation, finalRotation);
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.rotation = Quaternion.Euler(Vector3.Lerp(initialRotation, finalRotation, fractionOfJourney)); //need quat junk
    }
}