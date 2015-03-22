using UnityEngine;
using System.Collections;

public class stunt2 : MonoBehaviour {

	Animator anim;

	void Update () 
	{
		if (PlayerMovement1.attaque== true && prendrePowerUp1.estGros == true) 
			StartCoroutine (stunted ());
	}

	IEnumerator stunted(){
		anim = GetComponent <Animator> ();
		bool running = false;
		anim.SetBool ("IsRunning", running);
		PlayerMovement1.attaque= false;
		transform.localScale = new Vector3 (2.0F, .5F, 2.0F); 
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		transform.localScale = new Vector3 (1.5F, 1.5F, 1.5F);
		PlayerMovement2.speed = 8.0F;
		
		
		
	}
}
