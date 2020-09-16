using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDevil1 : MonoBehaviour
{
    public Vector3 position;
    public float moveSpeed;
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
               Mathf.Sin(counter) * distanceFromCenter, 0, Mathf.Cos(counter) * distanceFromCenter); //orbit - x and z plane 

        counter += (Time.deltaTime * moveSpeed);

    }
}
