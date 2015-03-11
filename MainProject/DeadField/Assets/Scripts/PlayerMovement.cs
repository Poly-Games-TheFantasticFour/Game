using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	//public float turnSmoothing = 15f;
	public float speed = 8.0f;
	public float jumpForce = 50.0f;
	//public float force = 25.0f;

	bool isGrounded = true;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	Animator anim;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	void FixedUpdate ()
	{
		playerRigidbody.AddForce(Physics.gravity * playerRigidbody.mass);
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (Input.GetButtonDown("Jump") && isGrounded) 
		{
			Jump ();
			isGrounded = false;
		}

		Move (h, v);
		Turning ();
		Attack ();

		/*if (h != 0 || v != 0)
			Rotate (h, v);*/
	}

	void Jump () 
	{
		playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}

	void Move (float h, float v)
	{
		Vector3 move = new Vector3 (h, 0.0f, v);
		transform.position += Vector3.ClampMagnitude (move, 1.0f) * speed * Time.deltaTime;

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
		if (Input.GetMouseButtonDown (0)) 
		{
			anim.SetTrigger ("Attack");
		}
	}

	void OnCollisionEnter()
	{
		isGrounded = true;
	}

	//***********************To implement - knockback*********************************************** 
	/*void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player")
			hit.rigidbody.AddForce (Vector3.forward * force);
	}*/

	// ************************Old rotate (via wasd)*************************
	/*void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		rigidbody.MoveRotation(newRotation);
	}*/
}