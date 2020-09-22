using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDevil_controller : MonoBehaviour
{

    public float expandSpeed = .5f; //cyclone width explansion rate 
    public float spinSpeed = -1; 
    public float riseSpeed = 1;
    public float height = 2;
    public float theta = 0;
    public float rise = 0.01f;
    public float expand;
    public float size=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.localPosition = new Vector3(expand * Mathf.Cos(theta), rise, expand * Mathf.Sin(theta));

        theta += Time.deltaTime * spinSpeed; //calculate new angle 

        rise += Time.deltaTime * riseSpeed; // Calculate distance between revolutions
        
        if ( height == 0 )
        {
            this.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            float scale = size * (1 - rise / height);
            this.transform.localScale = new Vector3(scale, scale, scale); //dirts will get smaller with rise sot they disappear 
        }


        expand = rise * expandSpeed; //radius 

        if (rise > height)
            rise = UnityEngine.Random.Range(0.0f, height);


    }
}
