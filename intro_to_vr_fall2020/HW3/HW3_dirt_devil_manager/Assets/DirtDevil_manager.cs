using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDevil_manager : MonoBehaviour
{
    public GameObject devil; // sepcs of dust and sand that will make up the tornado 
    public int dirt = 100; //how many sand particles there are swirling around 
    public GameObject[] devils; //Lots of devils 
    public List<GameObject> devilList; //all the devils 

    GameObject container;


    public float devilHeight = 0; //offset each devil in height
    public float speedOffset = 1; //offset each devil in speed 
    public float theatOffset = 1; //
    public float spinSpeedOffset = 10;
    public float expandOffset = 0;
    public float sizeOffset = 0; 


 
    


    void Start()
    {
        devils = new GameObject[dirt];
        devilList = new List<GameObject>();
        container = new GameObject();

        for (int i=0; i<dirt; i++)
        {
            devils[i] = Instantiate(devil, container.transform);
            devils[i].transform.GetChild(0).transform.localPosition = new Vector3(i * 0.01f, 0, 0);
            devils[i].GetComponent<DirtDevil_controller>().rise =  UnityEngine.Random.Range(0.0f, devilHeight);
            devils[i].GetComponent<DirtDevil_controller>().theta = UnityEngine.Random.Range(0, 360);
            devils[i].GetComponent<DirtDevil_controller>().spinSpeed = spinSpeedOffset + UnityEngine.Random.Range(-5, 5);
            devils[i].GetComponent<DirtDevil_controller>().height = devilHeight + UnityEngine.Random.Range(devilHeight+devilHeight*.2f, devilHeight - devilHeight * .2f);
            devils[i].GetComponent<DirtDevil_controller>().expandSpeed = expandOffset + UnityEngine.Random.Range(expandOffset + expandOffset * .1f, expandOffset - expandOffset * .1f);
            devils[i].GetComponent<DirtDevil_controller>().size = sizeOffset + UnityEngine.Random.Range(sizeOffset + sizeOffset * .05f, sizeOffset - sizeOffset * .05f);



        }
    }

    // Update is called once per frame
    void Update()
    {



    }

}
