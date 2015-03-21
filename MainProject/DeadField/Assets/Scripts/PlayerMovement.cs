using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	//public float turnSmoothing = 15f;
	public static float speed = 8.0f; //besoin detre static pour pouvoir sen servir dansun autre script
	public float jumpForce = 50.0f;
	public static float attactForce = 75.0f;
	public static float timeBetweenAttacks = 0.88f;
	public float attactRange = 2.0f;
	public float jumpCheckDist = 1.0f;
	public static bool attaque = false;
	public float attackRadius = 0.75f;

	public AudioClip getHitClip;
	public AudioClip attackClip;
	AudioSource playerSound;

	//bool isGrounded = true;
	int floorMask, hitMask, jumpMask;
	float camRayLength = 200f;
	float timer = 0.0f;

	Rigidbody playerRigidbody;
	Animator anim;
	RaycastHit shootHit, shootJump;
	Vector3 move;

	void Awake()
	{
		jumpMask = LayerMask.GetMask ("Jump");
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

		if (Input.GetButton("Jump") && IsGrounded()) 
		{
			Jump ();
			//isGrounded = false;
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

	bool IsGrounded()
	{
		Vector3 DirectionRay = transform.TransformDirection(Vector3.down);
		Vector3 right = new Vector3(0.25f,1.0f,0.0f);
		Vector3 left = new Vector3(-0.25f,1.0f,0f);
		Vector3 front = new Vector3(0.0f,1.0f,0.25f);
		Vector3 rear = new Vector3(0.25f,1.0f,-0.25f);

		Debug.DrawRay(transform.position + right, DirectionRay * jumpCheckDist, Color.blue);
		Debug.DrawRay(transform.position + left, DirectionRay * jumpCheckDist, Color.blue);
		Debug.DrawRay(transform.position + front, DirectionRay * jumpCheckDist, Color.blue);
		Debug.DrawRay(transform.position + rear, DirectionRay * jumpCheckDist, Color.blue);

		if(Physics.Raycast (transform.position + right, DirectionRay, out shootJump, jumpCheckDist, jumpMask))
		   return true;
		if(Physics.Raycast (transform.position + left, DirectionRay, out shootJump, jumpCheckDist, jumpMask))
			return true;
		if(Physics.Raycast (transform.position + front, DirectionRay, out shootJump, jumpCheckDist, jumpMask))
			return true;
		if(Physics.Raycast (transform.position + rear, DirectionRay, out shootJump, jumpCheckDist, jumpMask))
			return true;
		return false;
	}

	void Jump () 
	{
		playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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