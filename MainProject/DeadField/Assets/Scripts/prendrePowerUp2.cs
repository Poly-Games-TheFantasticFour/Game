using UnityEngine;
using System.Collections;


public class prendrePowerUp2 : MonoBehaviour {

	float getspeed = PlayerMovement2.speed; 					//accede au variable dun autre script(PlayerMovement)
	float getattactForce = PlayerMovement2.attactForce;		//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
	float gettimeBetweenAttacks = PlayerMovement2.timeBetweenAttacks;
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
		transform.localScale = new Vector3 (3F, 3F, 3F); 
		transform.rigidbody.mass = 9.5F; 
		PlayerMovement2.speed = 6.0F;
		PlayerMovement2.attactForce = 100.0F;
		PlayerMovement2.timeBetweenAttacks = 0.88f;
	}
	void petit (){
		transform.localScale = new Vector3 (0.75F, 0.75F, 0.75F); 
		transform.rigidbody.mass = 5f; 
		PlayerMovement2.speed = 10F;
		PlayerMovement2.timeBetweenAttacks = 0.40F;
		PlayerMovement2.attactForce = 50.0f;
	}
	void normal(){
		estGros = false;
		estActif = false;
		tempsActivation = 0.0f;
		transform.localScale = new Vector3 (1.5F, 1.5F, 1.5F); 
		transform.rigidbody.mass = 6f; 
		PlayerMovement2.speed = 8F;
		PlayerMovement2.attactForce = 50.0f;
		PlayerMovement2.timeBetweenAttacks = 0.88f;


	}


}
