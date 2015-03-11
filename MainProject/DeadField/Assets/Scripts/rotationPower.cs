using UnityEngine;
using System.Collections;

public class rotationPower : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 240, 0)*Time.deltaTime);
	
	}
}
