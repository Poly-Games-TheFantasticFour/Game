using UnityEngine;
using System.Collections;

public class stunt2 : MonoBehaviour {

	public static bool estStrunt2 = false;
	Animator anim;

	void OnTriggerStay (Collider other)
	{
		if ((Attack1.attaque == true && prendrePowerUp1.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player1"))|| 
		    (Attack3.attaque == true && prendrePowerUp3.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player3"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/)
			StartCoroutine (stunted ());
		
	}

	IEnumerator stunted(){
		estStrunt2 = true;
		anim = GetComponent <Animator> ();
		bool running = false;
		anim.SetBool ("IsRunning", running);
		Attack1.attaque= false;
		transform.localScale = new Vector3 (2.0F, .5F, 2.0F); 
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		transform.localScale = new Vector3 (1.5F, 1.5F, 1.5F);
		PlayerMovement2.speed = 8.0F;
		
		
		
	}
}
