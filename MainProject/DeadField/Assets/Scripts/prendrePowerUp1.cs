﻿using UnityEngine;
using System.Collections;


public class prendrePowerUp1 : MonoBehaviour {
	
	public static bool estGros = false;
	public float tempsActivation = 10.0f;
	
	int quelPowerUp;
	int actif = -1;
	int nPowerup = 3;
	bool estPetit = false;
	bool estGlow = false;
	
	Component halo;
	
	void Awake()
	{
		halo = GameObject.Find("eye").GetComponent("Halo");
		normal();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			Destroy (other.gameObject);
			
			do{
				quelPowerUp = Random.Range(0,nPowerup); // 0 est inclu, nPowerUp est exclus
			}while(quelPowerUp == actif);
			
			switch(quelPowerUp)
			{
			case 0: actif = 0; StartCoroutine (grossir());
				break;
			case 1: actif = 1; StartCoroutine (petit());
				break;
			case 2: actif = 2; StartCoroutine (glow ());
				break;
			}
		}
	}
	
	IEnumerator grossir(){
		PlayerMovement1.attaque = false;
		estGros = true;
		estPetit = estGlow  = false;
		
		transform.localScale = new Vector3 (10.0F, 10.0F, 10.0F); 
		transform.rigidbody.mass = 8F; 
		PlayerMovement1.speed = 6.0F;					//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
		PlayerMovement1.attactForce = 100.0F;
		PlayerMovement1.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGros)
			normal ();
	}
	
	IEnumerator petit (){
		estPetit = true;
		estGros = estGlow = false;
		
		transform.localScale = new Vector3 (2.8F, 2.8F, 2.8F); 
		transform.rigidbody.mass = 5f; 
		PlayerMovement1.speed = 10F;
		PlayerMovement1.timeBetweenAttacks = 0.40F;
		PlayerMovement1.attactForce = 50.0f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estPetit)
			normal ();
	}
	
	IEnumerator glow(){
		estGlow = true;
		estPetit = estGros = false;
		
		transform.rigidbody.mass = 6f; 
		PlayerMovement1.speed = 8F;
		PlayerMovement1.attactForce = 75.0f;
		PlayerMovement1.timeBetweenAttacks = 0.88f;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F);
		
		halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGlow)
			normal ();
	}
	
	void normal(){
		estGros = estPetit = estGlow = false;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F); 
		transform.rigidbody.mass = 6f; 
		PlayerMovement1.speed = 8F;
		PlayerMovement1.attactForce = 75.0f;
		PlayerMovement1.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
