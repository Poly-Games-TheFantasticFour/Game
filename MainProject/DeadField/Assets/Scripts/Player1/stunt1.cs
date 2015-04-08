using UnityEngine;
using System.Collections;

public class stunt1 : MonoBehaviour {

	public static bool estStrunt1 = false;
	Animator anim; //ici
	public float stunTime = 1.0f;
	public float limitMovementTime = 0.2f;

	void OnTriggerStay (Collider other)
	{
		if ((Attack2.attaque == true && prendrePowerUp2.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player2")) || 
			(Attack3.attaque == true && prendrePowerUp3.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player3"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/)
				StartCoroutine (stunted(other));


		if ((Attack2.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player2"))|| 
		    (Attack3.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player3"))/*|| //permettre le joureur 4 de stunt le joueur1
		    (Attack4.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player4"))*/)
				StartCoroutine (LimitMovements(other));
	}

	IEnumerator stunted(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player2")) {
			Attack2.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player3")) {
			Attack3.attaque = false;
		}
		/*if (player.gameObject.layer == LayerMask.NameToLayer ("Player4")) {
			Attack4.attaque = false;
		}*/
		estStrunt1 = true;
		anim = GetComponent <Animator> (); //ici
		anim.SetBool ("IsRunning", false); // ici
		transform.localScale = new Vector3 (7.0F, 1.0F, 7.0F); 
		PlayerMovement1.speed = 0.0F;
		yield return new WaitForSeconds (stunTime);
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F);
		PlayerMovement1.speed = 8.0F;
	}
	
	IEnumerator LimitMovements(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player2")) {
			Attack2.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player3")) {
			Attack3.attaque = false;
		}
		/*if (player.gameObject.layer == LayerMask.NameToLayer ("Player4")) {
			Attack4.attaque = false;
		}*/
		anim = GetComponent <Animator> (); //ici
		anim.SetBool ("IsRunning", false); // ici
		PlayerMovement1.speed = 0.0F;
		yield return new WaitForSeconds (limitMovementTime);
		PlayerMovement1.speed = 8.0F;
	}
}