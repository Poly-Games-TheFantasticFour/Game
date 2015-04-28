using UnityEngine;
using System.Collections;

public class stunt4 : MonoBehaviour {

	public static bool estStrunt4 = false;
	Animator anim;
	public float stunTime = 1.0f;
	public float limitMovementTime = 0.2f;

	void OnTriggerStay (Collider other)
	{
		if ((Attack1.attaque == true && prendrePowerUp2.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player1")) || 
			(Attack2.attaque == true && prendrePowerUp3.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player2")) ||
		    (Attack3.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player3")))
				StartCoroutine (stunted(other));

		if ((Attack1.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player1")) || 
		    (Attack2.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player2")) || 
		    (Attack3.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player3")))
				StartCoroutine (LimitMovements(other));
	}

	IEnumerator stunted(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player1")) {
			Attack1.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player2")) {
			Attack2.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player3")) {
			Attack3.attaque = false;
		}
		estStrunt4 = true;
		anim = GetComponent <Animator> ();
		anim.SetBool ("IsRunning", false);
		transform.localScale = new Vector3 (3.25F, 0.75F, 3.25F); 
		PlayerMovement4.speed = 0.0F;
		yield return new WaitForSeconds (stunTime);
		transform.localScale = new Vector3 (2.25F, 2.25F, 2.25F);
		PlayerMovement4.speed = 8.0F;
	}
	
	IEnumerator LimitMovements(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player1")) {
			Attack1.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player2")) {
			Attack2.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player3")) {
			Attack3.attaque = false;
		}
		anim = GetComponent <Animator> ();
		anim.SetBool ("IsRunning", false);
		PlayerMovement4.speed = 0.0F;
		yield return new WaitForSeconds (limitMovementTime);
		PlayerMovement4.speed = 8.0F;
	}
}