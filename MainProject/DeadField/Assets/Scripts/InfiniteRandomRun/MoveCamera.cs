using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float timeBeforeMoving = 3.5f;
	bool started = false;
	float cameraSpeed = 3.0f;

	void Start()
	{
		Invoke ("Enabler", timeBeforeMoving);
	}

	void FixedUpdate () 
	{
		if(started)
			transform.position += (Vector3.forward * cameraSpeed * Time.deltaTime);
	}

	void Enabler()
	{
		started = true;
	}
}
