using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;






    public class BoatEngine2 : MonoBehaviour { 

    public SteamVR_Action_Boolean ForwardAction;
    public SteamVR_Action_Boolean RightAction;
    public SteamVR_Action_Boolean LeftAction;
    public Hand hand;
    public SteamVR_Input_Sources handType;
        public float Thrust = 5.0f;
        private Rigidbody BoatRB;
    public float steerFactor = 10f;

        // Use this for initialization
        void Start()
        {
           
         BoatRB = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

            if (SteamVR_Input._default.inActions.Forward.GetStateDown(hand.handType))
            {
                BoatRB.AddForce(new Vector3(0,0,1)* Thrust);
                

            }

            if (SteamVR_Input._default.inActions.Right.GetStateDown(hand.handType))
            {
                BoatRB.AddForce(new Vector3(1, 0, 1) * -Thrust * steerFactor);
              


            }

            if (SteamVR_Input._default.inActions.Left.GetStateDown(hand.handType))
            {
                BoatRB.AddForce(new Vector3(1, 0, 1) * Thrust * steerFactor);
            }

        }






    }

