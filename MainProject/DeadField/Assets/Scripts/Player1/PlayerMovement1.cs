using UnityEngine;
using System.Collections;

public class PlayerMovement1 : MonoBehaviour
{
	public float turnSmoothing = 15f;
	public static float speed = 8.0f; //besoin detre static pour pouvoir sen servir dansun autre script
	public float jumpForce = 50.0f;

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
	
	void FixedUpdate ()
	{
		playerRigidbody.AddForce(Physics.gravity * playerRigidbody.mass);
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		if (Input.GetButton("Jump") && isGrounded) 
		{
			Jump();
		}
		
		Move (h, v);
		//Turning ();

		if (h != 0 || v != 0)
			Rotate (h, v);
	}

	void Jump()
	{
		playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
	
	//************************Trigger Related functions*************************
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Jump")) {
			isGrounded = true;
		}
	}

	// ************************Old rotate (via wasd)*************************
	void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		rigidbody.MoveRotation(newRotation);
	}
}