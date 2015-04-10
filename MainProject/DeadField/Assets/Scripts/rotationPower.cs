using UnityEngine;
using System.Collections;

public class rotationPower : MonoBehaviour {
	public int tempsDePressence = 20;
	void Start () 
	{
		Destroy(gameObject,tempsDePressence);
	}

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 240, 0)*Time.deltaTime);

	}
	

}
