using UnityEngine;
using System.Collections;

public class Stunt3 : MonoBehaviour {
	
	public static bool estStrunt3 = false;
	Animator anim; //ici
	
	void OnTriggerStay (Collider other)
	{
		if ((Attack1.attaque == true && prendrePowerUp1.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player1"))|| 
		    (Attack2.attaque == true && prendrePowerUp2.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player2"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/)
			StartCoroutine (stunted ());
		
	}
	
	IEnumerator stunted(){
		estStrunt3 = true;
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
