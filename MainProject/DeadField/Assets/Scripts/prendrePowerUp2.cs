using UnityEngine;
using System.Collections;


public class prendrePowerUp2 : MonoBehaviour {
	float getspeed=PlayerMovement.speed; 					//accede au variable dun autre script(PlayerMovement)
	float getattactForce=PlayerMovement.attactForce;		//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
	float gettimeBetweenAttacks=PlayerMovement.timeBetweenAttacks;
	float quelPowerUp;
	float nPowerup = 2.0F;
	public static bool estGros = false;

	float tempsActivation = 0.0f; 
	bool estActif = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			other.gameObject.SetActive(false);
			tempsActivation =10.0f;
			quelPowerUp = Random.Range(0,nPowerup); // 0 est inclu, nPowerUp est exclus
			if(estActif == true){
				tempsActivation = 10.0f;
				if (quelPowerUp < 1f ){ // grossit le Player
					grossir();
				}
				else { //quelPowerUp >= 1 pour linstant) // rapetisse le Player
					petit(); 
				}
			}
			else {
				if (quelPowerUp < 1f ){ // grossit le Player
					grossir();
				}
				else { //quelPowerUp >= 1 pour linstant) // rapetisse le Player
					petit(); 
				}
				}

			StartCoroutine (actif());
		}

	}

	IEnumerator actif(){
	
		estActif = true;
		float time = 0;
		while (time < (tempsActivation * Time.deltaTime)) {
			time += Time.deltaTime;
			yield return new WaitForSeconds(1.0F);
		}
		if (time >= (tempsActivation * Time.deltaTime)) { // remet les paramettre modifier a leur valeur initiale
			normal(); 

		}

	}
	void grossir(){
		estGros = true;
		transform.localScale = new Vector3 (10F, 10F, 10F); 
		transform.rigidbody.mass = 9.5F; 
		PlayerMovement.speed =6.0F;
		PlayerMovement.attactForce =125.0F;
		PlayerMovement.timeBetweenAttacks =0.88f;
	}
	void petit (){
		transform.localScale = new Vector3 (2.8F, 2.8F, 2.8F); 
		transform.rigidbody.mass = 5f; 
		PlayerMovement.speed =10F;
		PlayerMovement.timeBetweenAttacks =0.40F;
		PlayerMovement.attactForce =50.0f;
	}
	void normal(){
		estGros = false;
		estActif = false;
		tempsActivation = 0.0f;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F); 
		transform.rigidbody.mass = 6f; 
		PlayerMovement.speed =8F;
		PlayerMovement.attactForce =50.0f;
		PlayerMovement.timeBetweenAttacks =0.88f;


	}


}
