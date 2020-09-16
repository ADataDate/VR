/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class zoomToDevil : MonoBehaviour
{ 

public Vector3 startPosition;
public Vector3 endPosition;
public float t;
public float speed = 0.5f;
private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceOverTime = (Time.deltaTime - startTime) * speed;
        float journey = distanceOverTime/
        Camera.main.transform.position = Vector3.Lerp(startPosition, endPosition, t); //later learned that t needs to be between 0 and 1 and become the the travel towards the end position. 

        //NEED A DELAY!!!!
        //HOW TO STOP THE CAMERA FROM MOVING ONCE IT IS WHERE I WANT IT TO BE? 
    }
}
**/
// A longer example of Vector3.Lerp usage.
// Drop this script under an object in your scene, and specify 2 other objects in the "startMarker"/"endMarker" variables in the script inspector window.
// At play time, the script will move the object along a path between the position of those two markers.

using UnityEngine;
using System.Collections;

public class zoomToDevil : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Vector3 startPosition;
    public Vector3 endPosition;

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
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }
}
