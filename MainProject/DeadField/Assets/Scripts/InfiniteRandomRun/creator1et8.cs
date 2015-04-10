using UnityEngine;
using System.Collections;

public class creator1et8 : MonoBehaviour {

	public GameObject plateforme;
	public float numberPoolSize = 2f;
	public float timeBeforeSpawning = 3f;
	float distance = 0f;
	float plateformLength = 5f;
	float keyNumber = 1f;
	float number;
	public int NplateformeCree = 2;
	
	void Start () 
	{
		Invoke ("Spawn", timeBeforeSpawning);
		distance = transform.position.z;
	}
	
	void FixedUpdate()
	{
		if (NplateformeCree != 0 && transform.position.z - distance >= plateformLength) 
		{
			distance = transform.position.z;
			Spawn ();
			NplateformeCree -= 1; 
		}
	}
	
	void Spawn()
	{
		number = Random.Range (0f, numberPoolSize);
		if(number < keyNumber)
			Instantiate (plateforme, transform.position, Quaternion.identity);
	
	}
}
