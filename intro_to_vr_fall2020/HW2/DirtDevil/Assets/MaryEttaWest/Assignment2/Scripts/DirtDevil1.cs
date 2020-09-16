using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDevil1 : MonoBehaviour
{
    public Vector3 position;
    public Vector3 scale = Vector3.one;
    public float moveSpeed;
    public Vector3 rotation;
    float counter = 0;
    public float distanceFromCenter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(
               Mathf.Sin(counter)*distanceFromCenter,0,Mathf.Cos(counter)*distanceFromCenter); //orbit - x and z plane 
        //this.transform.localScale = scale;
        //this.transform.localEulerAngles = rotation;
        counter += Time.deltaTime*moveSpeed;
        //this.transform.Translate(position.normalized * Time.deltaTime*moveSpeed);
        //this.transform.Rotate(rotation * moveSpeed);
        //print(Time.deltaTime);
        //print(counter);
    }
}
