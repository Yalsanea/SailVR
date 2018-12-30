using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class Shoot : MonoBehaviour {
	
	public SteamVR_Action_Boolean shootAction;
	public Hand hand ;
	public SteamVR_Input_Sources handType;
	public GameObject ArrowShot;
	public float fireRate = 0.05f;
	public float speed = 10f;
	
	
	public Transform gunEnd; //hookshot tip of gun
	private WaitForSeconds shotDuration = new WaitForSeconds(2f);
	private float nextFire;
	
	
	
	

	
	
	private void Update() {	
	
		if(SteamVR_Input._default.inActions.Shoot.GetStateDown(hand.handType)&& Time.time > nextFire){
		
		
		nextFire = Time.time + fireRate;   //time to n ext fire
		StartCoroutine (Shot());  //shoot
		
	}
	}
	
	
		IEnumerator Shot(){
	
	
		GameObject dupeArrow = Instantiate(ArrowShot,gunEnd.position,gunEnd.rotation) as GameObject;
		dupeArrow.transform.position = gunEnd.transform.position;
		Rigidbody rb = dupeArrow.GetComponent<Rigidbody>();
		rb.velocity = gunEnd.transform.forward * speed;
	
	
		yield return shotDuration;

		
		}
		
	
	



}
