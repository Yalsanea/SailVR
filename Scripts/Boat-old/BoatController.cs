using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FloatObject))]    //require float script


public class BoatController : MonoBehaviour {

    public Vector3 COM;
    Transform m_COM;

    public float speed = 1.0f;
    public float movementThreshold = 10.0f;
    public float steerSpeed = 1.0f;
    float verticalInput;
    float movementFactor;
    float horizontalInput;
    float steerFactor;
    // Update is called once per frame
    void Update () {
        Balance();
     //  Movement();
     //   Steer();
	}

    void Balance()
    {

        if (!m_COM){
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
        }

        m_COM.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;

    }


    void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        transform.Translate(0f, 0f, movementFactor * speed);

    }

    void Steer()
    {
        horizontalInput= Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput *verticalInput, Time.deltaTime / movementThreshold);
        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
    }


}
