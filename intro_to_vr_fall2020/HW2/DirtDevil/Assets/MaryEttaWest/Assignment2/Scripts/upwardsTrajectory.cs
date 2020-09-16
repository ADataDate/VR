using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upwardsTrajectory : MonoBehaviour
{
    //public float upwardSpeed; //want a slow and constant speed

    //float radius = 1; //distance from center of the eye
    float theta =0.157f; //angle of change 
   // float alpha =1; //angle between x and y plane 
   // float progress = 1; //multiplier



    //public float angleOfDeparture; //Only want to increase the upward spiraling effect from the center of the eye of storm 
    //public float speedOfDeparture; //want constant speed 
    //float counter = 0;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.localPosition = new Vector3(2*theta*Mathf.Cos(theta),2*theta*Mathf.Sin(theta), 2*theta);
        //radius = radius + (1/4);
        theta = theta + 0.157f;
       // alpha = alpha + 30;
        //if (radius >= 2)
        //{
          //  radius = 1;
        //}
        //if(progress >=6)
        //{
          //  progress = 1;
        //}
        if(theta >= 6.28)
        {
            theta = 0.314f;
        }
       // if (alpha >= 90) ;
        //alpha = 1;
        //progress = progress + 1;
       // yield WaitForSeconds(2); // how to add a delay? 

    }

}
