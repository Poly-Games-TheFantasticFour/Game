using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float turnSmoothing = 15f;
	public float speed = 6.0f;
	public float jumpSpeed = 6.0f;
	bool isGrounded = false;
	
	void FixedUpdate ()
	{

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (Input.GetButtonDown("Jump") && isGrounded)
			Jump ();


		Move (h, v);

		if (h != 0 || v != 0)
			Rotate (h, v);
	}
	
	void Rotate (float horizontal, float vertical)
	{
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		rigidbody.MoveRotation(newRotation);
	}

	void Move (float horizontal, float vertical)
	{
		transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
		transform.position += Vector3.forward * vertical * speed * Time.deltaTime;

	}

	void Jump () 
	{
		rigidbody.AddForce(Vector3.up * jumpSpeed);
		isGrounded = false;
	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}



}