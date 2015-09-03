using UnityEngine;
using System.Collections;

public class stunt2 : MonoBehaviour {
	
	public static bool estStrunt2 = false;
	public float stunTime = 1.0f;
	public float limitMovementTime = 0.2f;
	Animator anim;
	
	void OnTriggerStay (Collider other)
	{
		if ((Attack1.attaque == true && prendrePowerUp1.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player1")) || 
			(Attack3.attaque == true && prendrePowerUp3.estGros == true && other.gameObject.layer == LayerMask.NameToLayer ("Player3")) ||
		    (Attack4.attaque == true && prendrePowerUp4.estGros == true && other.gameObject.layer == LayerMask.NameToLayer("Player4")))
				StartCoroutine (stunted (other));

		if ((Attack1.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player1")) || 
		    (Attack3.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player3")) ||
		    (Attack4.attaque == true && other.gameObject.layer == LayerMask.NameToLayer("Player4")))
				StartCoroutine (LimitMovements(other));
	}
	
	IEnumerator stunted(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player1")) {
			Attack1.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player3")) {
			Attack3.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player4")) {
			Attack4.attaque = false;
		}
		estStrunt2 = true;
		anim = GetComponent <Animator> ();
		anim.SetBool ("IsRunning", false);
		transform.localScale = new Vector3 (2.0F, 0.5F, 2.0F); 
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (stunTime);
		estStrunt2 = false;
		transform.localScale = new Vector3 (1.5F, 1.5F, 1.5F);
		PlayerMovement2.speed = 8.0F;
	}
	
	IEnumerator LimitMovements(Collider player){
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player1")) {
			Attack1.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player3")) {
			Attack3.attaque = false;
		}
		if (player.gameObject.layer == LayerMask.NameToLayer ("Player4")) {
			Attack4.attaque = false;
		}
		anim = GetComponent <Animator> ();
		anim.SetBool ("IsRunning", false);
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (limitMovementTime);
		PlayerMovement2.speed = 8.0F;
	}
}
