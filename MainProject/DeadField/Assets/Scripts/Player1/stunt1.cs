using UnityEngine;
using System.Collections;

public class stunt1 : MonoBehaviour {

	Animator anim; //ici

	void Update () 
	{
		if (Attack2.attaque== true && prendrePowerUp2.estGros == true)
			StartCoroutine (stunted ());
	}

	IEnumerator stunted(){
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
