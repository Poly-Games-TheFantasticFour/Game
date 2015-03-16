using UnityEngine;
using System.Collections;

public class stunt1 : MonoBehaviour {
	bool getattaque=PlayerMovement2.attaque;
	float getspeed=PlayerMovement.speed; 
	Animator anim; //ici

	void Update () 
	{
		if (PlayerMovement2.attaque== true && prendrePowerUp2.estGros == true)
			StartCoroutine (stunted ());
	}

	IEnumerator stunted(){
		anim = GetComponent <Animator> (); //ici
		bool running = false;
		anim.SetBool ("IsRunning", running); // ici
		PlayerMovement2.attaque = false;
		yield return new WaitForSeconds(.1F);
		PlayerMovement.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		PlayerMovement.speed = 8.0F;
		
		
		
	}
}
