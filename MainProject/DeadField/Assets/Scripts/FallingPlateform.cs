using UnityEngine;
using System.Collections;

public class FallingPlateform : MonoBehaviour {

	public float timeBetweenNumber = 1.0f;
	public int numberPoolSize = 25;
	int keyNumber = 7;
	int number = 0;
	//float time = 0f;


	void Awake () 
	{
		StartCoroutine (actif());
	}

	/*void fixedUpdate () 
	{
		time += Time.deltaTime;
	}*/

	IEnumerator actif()
	{
		while (number != keyNumber) 
		{
			//if (time >= timeBetweenNumber)
			//{
				number = Random.Range(0, numberPoolSize);
			//	time = 0f;
		//	}
			yield return new WaitForSeconds(timeBetweenNumber);
		}
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
	}






	// Update is called once per frame
	/*void fixedUpdate () 
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
	}*/

}
