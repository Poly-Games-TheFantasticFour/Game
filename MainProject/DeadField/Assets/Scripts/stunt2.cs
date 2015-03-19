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
		transform.localScale = new Vector3 (2.0F, .5F, 2.0F); 
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		transform.localScale = new Vector3 (1.5F, 1.5F, 1.5F);
		PlayerMovement2.speed = 8.0F;
		
		
		
	}
}
