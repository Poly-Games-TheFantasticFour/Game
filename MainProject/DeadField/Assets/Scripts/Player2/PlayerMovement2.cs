﻿using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour {

	public float turnSmoothing = 15f;
	public static float speed = 8.0f; //besoin detre static pour pouvoir sen servir dansun autre script
	public float jumpForce = 10.0f;
	public float gravity = 1.75f;
	
	Vector3 move;
	bool isGrounded = true;
	//int floorMask;
	//float camRayLength = 200f;
	
	Rigidbody playerRigidbody;
	Animator anim;
	
	void Awake()
	{
		//floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	char NbController ()
	{
		if (Input.GetJoystickNames ().Length < 2)
			return 'K';
		else
			return 'C';
	}

	void Update ()
	{
		playerRigidbody.AddForce(Physics.gravity * playerRigidbody.mass * gravity);
		float h = Input.GetAxis ("HorizontalP2" + NbController());
		float v = Input.GetAxis ("VerticalP2" + NbController());
		
		if (Input.GetButton("JumpP2") && isGrounded) 
		{
			Jump ();
		}
		
		Move (h, v);
		//Turning ();
		
		if (h != 0 || v != 0)
			Rotate (h, v);
	}
	
	void Jump()
	{
		anim.SetTrigger ("Jump");
		playerRigidbody.velocity = new Vector3 (0, jumpForce, 0);
		//playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		isGrounded = false;
	}
	
	void Move (float h, float v)
	{
		move.Set (h, 0f, v);
		playerRigidbody.MovePosition (transform.position + Vector3.ClampMagnitude (move, 1.0f) * speed * Time.deltaTime);

		bool running = h != 0f || v != 0f;
		anim.SetBool ("IsRunning", running);
	}
	
	/*void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}*/

	// ************************Old rotate (via wasd)*************************
	void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

		GetComponent<Rigidbody>().MoveRotation(newRotation);
	}

	//************************Trigger Related functions*************************
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Jump")) {
			isGrounded = true;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		isGrounded = false;
	}
}