using UnityEngine;
using System.Collections;

public class Stunt3 : MonoBehaviour {
	
	public static bool estStrunt3 = false;
	public float stunTime = 1.0f;
	public float limitMovementTime = 0.2f;
	Animator anim; //ici
	
	void OnTriggerStay (Collider other)
	{
		if ((Attack1.attaque == true && prendrePowerUp1.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player1")) || 
		    (Attack2.attaque == true && prendrePowerUp2.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player2"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/) {
			StartCoroutine (stunted (other));
		}
		
		if ((Attack1.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player1"))|| 
		    (Attack2.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player2"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/)
			StartCoroutine (LimitMovements(other));
	}
	
	IEnumerator stunted(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player1")) {
			Attack1.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player2")) {
			Attack2.attaque = false;
		}
		/*if (player.gameObject.layer == LayerMask.NameToLayer ("Player4")) {
			Attack4.attaque = false;
		}*/
		estStrunt3 = true;
		anim = GetComponent <Animator> (); //ici
		anim.SetBool ("IsRunning", false); // ici
		transform.localScale = new Vector3 (2.0F, 0.5F, 2.0F); 
		PlayerMovement3.speed = 0.0F;
		yield return new WaitForSeconds (stunTime);
		transform.localScale = new Vector3 (1.75F, 1.75F, 1.75F);
		PlayerMovement3.speed = 8.0F;
	}
	
	IEnumerator LimitMovements(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player1")) {
			Attack1.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player2")) {
			Attack2.attaque = false;
		}
		/*if (player.gameObject.layer == LayerMask.NameToLayer ("Player4")) {
			Attack4.attaque = false;
		}*/
		anim = GetComponent <Animator> (); //ici
		anim.SetBool ("IsRunning", false); // ici
		PlayerMovement3.speed = 0.0F;
		yield return new WaitForSeconds (limitMovementTime);
		PlayerMovement3.speed = 8.0F;
	}
}
