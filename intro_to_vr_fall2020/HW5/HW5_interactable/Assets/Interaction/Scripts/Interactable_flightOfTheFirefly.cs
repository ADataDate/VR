using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CUVR;
public class Interactable_flightOfTheFirefly : Interactable
{
    public AudioSource sound;
    public AudioClip clip;

    private Vector3 startPosition;
    public Vector3 endPosition;
    public float t;
    public float speed = 10.0f;
    private float startTime;
    private float flightDistance;
    private bool flightStarted = false;
    public float transformFrequency = 1;
    public float transformAmplitude = 0.25f;
    public float transformPhase = 0;

    Vector3 translate = Vector3.zero;

    enum FlightState { Forward, Reverse };
    FlightState flightState;

    public void UpdatePosition()
    {
        if ( flightStarted == true )
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfFlight = distCovered / flightDistance;

            if ( flightState == FlightState.Reverse )
            {
                fractionOfFlight = 1 - fractionOfFlight;
            }

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfFlight);

            if (flightState == FlightState.Forward && fractionOfFlight > .99)
            {
                flightStarted = false;
                flightState = FlightState.Reverse;
            }
            else if (flightState == FlightState.Reverse && fractionOfFlight < .01)
            {
                flightStarted = false;
                flightState = FlightState.Forward;
            }
        }
        if ( flightStarted==false )
        {
            float transformY = Mathf.Sin(Time.time * transformFrequency * speed + transformPhase) * transformAmplitude;
            if (flightState == FlightState.Forward)
            {
                translate.Set(startPosition.x, startPosition.y + transformY, startPosition.z);
            }
            else
            {
                translate.Set(endPosition.x, endPosition.y + transformY, endPosition.z);
            }
            this.transform.localPosition = translate;
        }
    }

    public override void HandleStart()
    {
        base.HandleStart();

        // Calculate the journey length.

        flightState = FlightState.Forward;
        startPosition = transform.position;
   

        if (clip != null)
        {
            sound.clip = clip;
        }
    }

    public override void HandleEnter()
    {
        base.HandleEnter();

        if ( flightStarted == false )
        {
            if ( flightState == FlightState.Forward )
            {
                flightDistance = Vector3.Distance(startPosition, endPosition);
                sound.Play();
            }
            else
            {
                flightDistance = Vector3.Distance(endPosition, startPosition);
                sound.Stop();
            }

            flightStarted = true;
            startTime = Time.time;
        }

        UpdatePosition();
    }

    public override void HandleWaiting()
    {
        base.HandleWaiting();

        UpdatePosition();
    }

    public override void HandleHover()
    {
        base.HandleHover();

        UpdatePosition();
    }

    public override void HandleExit()
    {
        base.HandleExit();

        UpdatePosition();
    }
}
