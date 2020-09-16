using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upwardsTrajectory : MonoBehaviour
{
    public GameObject spec; // sepcs of dust and sand that will mak eup the tornado 
    public int DirtDensity = 2; //how many sand particles there are swirlign arounf 
    public float expandSpeed = 3;
    public float spinSpeed = 1;
    public float riseSpeed = 1;
    public float height = 2;
    float theta=0; 
    public float rise=0.01f;
    public float expand;
    public float size;

 



    void Start()
    {
        //for (int i=0; i<DirtDensity; i++)
       // {
           // GameObject thisSpec = Instantiate(spec);
            //thisSpec.transform.GetChild(0).localPosition = new Vector3(i*0.01f, 0, 0);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.localPosition = new Vector3(expand*Mathf.Cos(theta),rise, expand * Mathf.Sin(theta));
        
        theta += Time.deltaTime * spinSpeed; //calculate new angle 

        rise += Time.deltaTime * riseSpeed; // Calculate distance between revolutions
        float scale = size * (1 - rise / height);

        this.transform.localScale = new Vector3(scale, scale, scale);

        expand = rise * expandSpeed; //radius 
   
        if(rise > height)
            rise = 0.01f;
       /* {
            for(float i = rise; i >0; i-- )
            this.transform.localPosition = new Vector3(expand * Mathf.Cos(theta), rise, expand * Mathf.Sin(theta));

            theta += Time.deltaTime * spinSpeed; //calculate new angle 

            rise += Time.deltaTime * riseSpeed; // Calculate distance between revolutions

            expand = rise * expandSpeed; //radius 
           
        }*/


    }

}
