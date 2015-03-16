using UnityEngine;
using System.Collections;

public class stunt2 : MonoBehaviour {
	bool getattaque=PlayerMovement.attaque;
	float getspeed=PlayerMovement2.speed;
	Animator anim;

	void Update () 
	{
		if (PlayerMovement.attaque== true && prendrePowerUp.estGros == true) 
			StartCoroutine (stunted ());
	}

	IEnumerator stunted(){
		anim = GetComponent <Animator> ();
		bool running = false;
		anim.SetBool ("IsRunning", running);
		PlayerMovement.attaque= false;
		yield return new WaitForSeconds (.1F);
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		PlayerMovement2.speed = 8.0F;
		
		
		
	}
}
