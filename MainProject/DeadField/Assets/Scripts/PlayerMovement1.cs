﻿using UnityEngine;
using System.Collections;

public class PlayerMovement1 : MonoBehaviour
{
	//public float turnSmoothing = 15f;
	public static float speed = 8.0f; //besoin detre static pour pouvoir sen servir dansun autre script
	public float jumpForce = 50.0f;
	public static float attactForce = 75.0f;
	public static float timeBetweenAttacks = 0.88f;
	public float attactRange = 2.0f;
	public static bool attaque = false;
	public float attackRadius = 0.75f;
	
	public AudioClip getHitClip;
	public AudioClip attackClip;
	AudioSource playerSound;
	Vector3 move;
	
	bool isGrounded = true;
	int floorMask, hitMask;
	float camRayLength = 200f;
	float timer = 0.0f;
	
	Rigidbody playerRigidbody;
	Animator anim;
	RaycastHit shootHit;
	
	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		hitMask = LayerMask.GetMask ("Melee");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		playerSound = GetComponent <AudioSource> ();
	}
	
	void FixedUpdate ()
	{
		timer += Time.deltaTime;
		
		playerRigidbody.AddForce(Physics.gravity * playerRigidbody.mass);
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		if (Input.GetButton("Jump") && isGrounded) 
		{
			Jump();
		}
		
		Move (h, v);
		Turning ();
		
		if (Input.GetButtonDown("Fire1")&& timer >= timeBetweenAttacks && Time.timeScale != 0) 
		{
			timer = 0.0f;
			anim.SetTrigger ("Attack");
			Invoke("Attack", .5f);
		}
		
		/*if (h != 0 || v != 0)
			Rotate (h, v);*/
	}

	void Jump()
	{
		playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		isGrounded = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Jump")) {
			isGrounded = true;
		}
	}
	
	void Move (float h, float v)
	{
		//Vector3 move = new Vector3 (h, 0.0f, v);
		//transform.position += Vector3.ClampMagnitude (move, 1.0f) * speed * Time.deltaTime;
		//playerRigidbody.MovePosition (playerRigidbody.position + Vector3.ClampMagnitude (move, 1.0f) * speed * Time.deltaTime);
		move.Set (h, 0f, v);
		playerRigidbody.MovePosition (transform.position + Vector3.ClampMagnitude (move, 1.0f) * speed * Time.deltaTime);
		
		bool running = h != 0f || v != 0f;
		anim.SetBool ("IsRunning", running);
	}
	
	void Turning()
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
	}
	
	void Attack()
	{
		Vector3 DirectionRay = transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (transform.position + transform.up, DirectionRay * attactRange, Color.blue);
		
		if (Physics.SphereCast (transform.position + transform.up, attackRadius, DirectionRay, out shootHit, attactRange, hitMask) || Physics.Raycast (transform.position + transform.up, DirectionRay, out shootHit, attactRange, hitMask)) 
		{
			shootHit.rigidbody.AddForce (DirectionRay.normalized * attactForce, ForceMode.Impulse); 
			playerSound.clip = getHitClip;
			attaque = true;
		}
		else
			playerSound.clip = attackClip;
		playerSound.Play ();
	}
	
	// ************************Old rotate (via wasd)*************************
	/*void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		rigidbody.MoveRotation(newRotation);
	}*/
}