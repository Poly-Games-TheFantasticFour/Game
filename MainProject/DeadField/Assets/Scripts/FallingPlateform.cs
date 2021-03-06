﻿using UnityEngine;
using System.Collections;

public class FallingPlateform : MonoBehaviour {

	public float timeBetweenNumber = 1.0f;
	public float timeInWhite = 0.5f;
	public int numberPoolSize = 25;
	int keyNumber = 7;
	int number = 0;

	void Awake () 
	{
		StartCoroutine (actif());
	}
	
	IEnumerator actif()
	{
		while (number != keyNumber) 
		{
				number = Random.Range(0, numberPoolSize);

			yield return new WaitForSeconds(timeBetweenNumber);
		}
		gameObject.GetComponent<Renderer>().material.color = Color.white;

		yield return new WaitForSeconds (timeInWhite);
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
	}

}
