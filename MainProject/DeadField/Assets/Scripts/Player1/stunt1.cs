﻿using UnityEngine;
using System.Collections;

public class stunt1 : MonoBehaviour {

	public static bool estStrunt1 = false;
	Animator anim; //ici

	void OnTriggerStay (Collider other)
	{
		if ((Attack2.attaque == true && prendrePowerUp2.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player2"))|| 
		    (Attack3.attaque == true && prendrePowerUp3.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player3"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/)
			StartCoroutine (stunted ());
	
	}

	IEnumerator stunted(){
		estStrunt1 = true;
		anim = GetComponent <Animator> (); //ici
		bool running = false;
		anim.SetBool ("IsRunning", running); // ici
		Attack2.attaque = false;
		//yield return new WaitForSeconds(.1F);
		transform.localScale = new Vector3 (7.0F, 1.0F, 7.0F); 
		PlayerMovement1.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F);
		PlayerMovement1.speed = 8.0F;
		
		
		
	}
}
