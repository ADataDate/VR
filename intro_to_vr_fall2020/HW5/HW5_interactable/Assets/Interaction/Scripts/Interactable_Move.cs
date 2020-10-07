using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CUVR{

    public class Interactable_Move : Interactable
    {
        //navigate to the raycast position
        public GameObject target;
        public Vector3 startPosition;
        public Vector3 endPosition;
        public float t;
        public float speed = 0.5f;
        private float startTime;
        private float flightDistance;


        public override void HandleHover()
        {
            if (gaze.button.buttonUp)
            {
                HandleTrigger();
            }
        }

        public override void HandleTrigger()
        {
            base.HandleTrigger();
            startTime = Time.time;
            // Calculate the journey length.
            flightDistance = Vector3.Distance(startPosition, endPosition);
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfFlight = distCovered / flightDistance;
            target.transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfFlight);
        }

    }
}