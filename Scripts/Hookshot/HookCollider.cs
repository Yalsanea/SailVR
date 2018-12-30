using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HookCollider : MonoBehaviour
{


    private GameObject Players;

    public float MinRange = 5f;
    public float MaxRange = 5f;
    private Transform hookpoint;
    public float pullSpeed = 3f;
    private bool hooked = false;
    // Use this for initialization
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Players = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {


        if(hooked == false)  //check if at max range
        {
            if(Vector3.Distance(Players.transform.position,transform.position) > MaxRange) 
            {
                Destroy(gameObject);
            }

        }

        if(hooked == true)   //pull if hooked
        {
            Rigidbody rb3 = Players.GetComponent(typeof(Rigidbody)) as Rigidbody;
          
            Debug.Log("Pulling!");
            //gameObject.AddComponent<SpringJoint>();
            //gameObject.GetComponent<SpringJoint>().connectedBody = rb3;
            //gameObject.GetComponent<SpringJoint>().minDistance = MinRange;
            //gameObject.GetComponent<SpringJoint>().maxDistance = MaxRange;
            hookpoint = gameObject.GetComponent<Transform>();

            float step = pullSpeed * Time.deltaTime;
        

            Players.transform.position = Vector3.MoveTowards(Players.transform.position, hookpoint.position - new Vector3(0,0.8f), step);    // the offset is for player position because this pulls the foot of the player and not the center of the body

            if (Players.transform.position == hookpoint.position - new Vector3(0, 0.8f))
            {
                hooked = false;
                Destroy(gameObject);
            }
        }
    }



    private void OnTriggerEnter(Collider other)  //collision with trigger
    {

        Debug.Log("Hit!");

        gameObject.AddComponent<FixedJoint>();
        Rigidbody rb2 = other.GetComponent(typeof(Rigidbody)) as Rigidbody;
        gameObject.GetComponent<FixedJoint>().connectedBody = rb2;
        hooked = true;
        
        




    }


}


    
