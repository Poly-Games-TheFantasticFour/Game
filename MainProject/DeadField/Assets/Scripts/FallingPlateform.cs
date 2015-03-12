using UnityEngine;
using System.Collections;

public class FallingPlateform : MonoBehaviour {

	public float timeBetweenNumber = 2.0f;
	public int numberPoolSize = 20;
	int keyNumber = 9;
	int number = 0;
	float timer = 0;

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= timeBetweenNumber && Time.timeScale != 0) 
			generateNumber ();
		if (number == keyNumber) 
		{
			rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
		}
	
	}

	void generateNumber()
	{
		number = Random.Range(0, numberPoolSize);
	}

}
