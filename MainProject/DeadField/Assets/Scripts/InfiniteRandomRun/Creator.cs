using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour {

	public GameObject plateforme;
	public float numberPoolSize = 2f;
	public float timeBeforeSpawning = 3.5f;
	float distance = 0f;
	float plateformLength = 5f;
	float keyNumber = 1f;
	float number;

	void Start () 
	{
		Invoke ("Spawn", timeBeforeSpawning);
		distance = transform.position.z;
	}

	void FixedUpdate()
	{
		if (transform.position.z - distance >= plateformLength) 
		{
			distance = transform.position.z;
			Spawn ();
		}
	}

	void Spawn()
	{
		number = Random.Range (0f, numberPoolSize);
		if(number < keyNumber)
			Instantiate (plateforme, transform.position, Quaternion.identity);
	}
}
