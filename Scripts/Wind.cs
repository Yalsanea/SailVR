using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{


    public float Strength = 1f;
    public Vector3 WindDirection = new Vector3(1,0,0);
    public Rigidbody SailRB;
    private float nextWind;
    public float windDuration = 3f;


    // Use this for initialization
    void Start()
    {
        
        Rigidbody SailRB = GetComponent<Rigidbody>();
       
    }

 
    void Update()
    {
        if (Time.time > nextWind)
        {
            nextWind = Time.time + windDuration;
            WindDirection = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
        }

        SailRB.AddForce(WindDirection * Strength, ForceMode.Acceleration);
        
        if (Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 20);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 20);
        }

    }

   
 

}
