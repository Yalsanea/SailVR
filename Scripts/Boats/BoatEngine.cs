using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;


namespace BoatMechanics
{
    public class BoatEngine : MonoBehaviour
    {

        public SteamVR_Action_Boolean ForwardAction;
        public SteamVR_Action_Boolean RightAction;
        public SteamVR_Action_Boolean LeftAction;
        public Hand hand;
        public SteamVR_Input_Sources handType;


        //Drags
        public Transform waterJetTransform;

        //How fast should the engine accelerate?
        public float powerFactor;

        //What's the boat's maximum engine power?
        public float maxPower;

        //The boat's current engine power is public for debugging
        public float currentJetPower;

        private float thrustFromWaterJet = 0f;

        private Rigidbody boatRB;

        private float WaterJetRotation_Y = 0f;

        BoatController boatController;

        void Start()
        {
            boatRB = GetComponent<Rigidbody>();

            boatController = GetComponent<BoatController>();
        }


        void Update()
        {
            UserInput();
        }

        void FixedUpdate()
        {
            UpdateWaterJet();
        }

        void UserInput()
        {
            //Forward / reverse


            if (SteamVR_Input._default.inActions.Forward.GetStateDown(hand.handType))
            {
                if (boatController.CurrentSpeed < 50f && currentJetPower < maxPower)
                {
                    currentJetPower += 1f * powerFactor;
                    Debug.Log("Forward");
                }

                else { 

                    currentJetPower = 0f;
                }
        }

            //Steer left
            if (SteamVR_Input._default.inActions.Left.GetStateDown(hand.handType))
            {
                Debug.Log("Left");
                WaterJetRotation_Y = waterJetTransform.localEulerAngles.y + 2f;

                if (WaterJetRotation_Y > 30f && WaterJetRotation_Y < 270f)
                {
                    WaterJetRotation_Y = 30f;
                }

                Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);

                waterJetTransform.localEulerAngles = newRotation;
            }
            //Steer right
           else if(SteamVR_Input._default.inActions.Right.GetStateDown(hand.handType))
            {
                Debug.Log("Right");
                WaterJetRotation_Y = waterJetTransform.localEulerAngles.y - 2f;

                if (WaterJetRotation_Y < 330f && WaterJetRotation_Y > 90f)
                {
                    WaterJetRotation_Y = 330f;
                }

                Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);

                waterJetTransform.localEulerAngles = newRotation;
            }
        }

        void UpdateWaterJet()
        {
            //Debug.Log(boatController.CurrentSpeed);

            Vector3 forceToAdd = -waterJetTransform.forward * currentJetPower;

            //Only add the force if the engine is below sea level
            float waveYPos = WaterController.current.GetWaveYPos(waterJetTransform.position, Time.time);

            if (waterJetTransform.position.y < waveYPos)
            {
                boatRB.AddForceAtPosition(forceToAdd, waterJetTransform.position);
            }
            else
            {
                boatRB.AddForceAtPosition(Vector3.zero, waterJetTransform.position);
            }
        }
    }
}