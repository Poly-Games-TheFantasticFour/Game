using UnityEngine;
using System.Collections;

public class stunt : MonoBehaviour {
	bool getattaque=PlayerMovement.attaque;
	float getspeed=PlayerMovement2.speed; 
	
	void Update () {
		if (PlayerMovement.attaque== true && prendrePowerUp.estGros == true) {
			StartCoroutine (stunted ());
		}
		
	}
	
	
	IEnumerator stunted(){
		PlayerMovement.attaque= false;
		yield return new WaitForSeconds(1.0F);
		PlayerMovement2.speed = 0.0F;
		yield return new WaitForSeconds (1.0F);
		PlayerMovement2.speed = 8.0F;
		
		
		
	}
}
