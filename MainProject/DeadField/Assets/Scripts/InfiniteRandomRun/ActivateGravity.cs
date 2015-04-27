using UnityEngine;
using System.Collections;

public class ActivateGravity : MonoBehaviour {

	float delay = 2f;

	// Use this for initialization
	void Start () {
		Invoke ("activateGravity", delay);
	}

	void activateGravity(){
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
	}
}