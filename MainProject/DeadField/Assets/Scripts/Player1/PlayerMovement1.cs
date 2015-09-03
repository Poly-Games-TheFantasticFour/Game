using UnityEngine;
using System.Collections;

public class PlayerMovement1 : MonoBehaviour
{
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
		//Check for connected controller to determine the intended input (controller/keyboard).
		if (Input.GetJoystickNames ().Length < 1)
			return 'K';
		else
			return 'C';
	}

	void FixedUpdate ()
	{
		//Move player according to inputs.
		playerRigidbody.AddForce(Physics.gravity * playerRigidbody.mass * gravity);
		float h = Input.GetAxis ("HorizontalP1" + NbController());
		float v = Input.GetAxis ("VerticalP1" + NbController());
		
		//Jump if touches the ground and input triggered.
		if (Input.GetButton("JumpP1") && isGrounded) 
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
		//Add vertical velocity to jump.
		playerRigidbody.velocity = new Vector3 (0, jumpForce, 0);
		isGrounded = false;
	}

	void Move (float h, float v)
	{
		//Move on the ground and use ClampMagnitude to normalize the diagonal run speed.
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
	//Check if player trigger collider is in contack wth the ground.
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

	// ************************Old rotate (via wasd)*************************
	//Rotate player according to direction (WASD) and use smoothing to make it look more natural.
	void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

		GetComponent<Rigidbody>().MoveRotation(newRotation);
	}
}