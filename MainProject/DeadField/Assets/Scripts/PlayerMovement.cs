using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	//public float turnSmoothing = 15f;
	public float speed = 8.0f;
	public float jumpForce = 50.0f;

	bool isGrounded = true;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	//Animator anim;
	
	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		//anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	void FixedUpdate ()
	{
		rigidbody.AddForce(Physics.gravity * rigidbody.mass);
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (Input.GetButtonDown("Jump") && isGrounded) 
		{
			Jump ();
			isGrounded = false;
		}

		Move (h, v);
		Turning ();

		/*if (h != 0 || v != 0)
			Rotate (h, v);*/
	}

	void Jump () 
	{
		rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}

	void Move (float horizontal, float vertical)
	{
		Vector3 move = new Vector3 (horizontal, 0.0f, vertical);
		transform.position += Vector3.ClampMagnitude (move, 1.0f) * speed * Time.deltaTime;
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
	// ************************Old rotate (via wasd)*************************
	/*void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		rigidbody.MoveRotation(newRotation);
	}*/
	
	//********************************To implement***********************
	/*void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);

	}*/

	void OnCollisionEnter()
	{
		isGrounded = true;
	}
}