using UnityEngine;
using System.Collections;


public class prendrePowerUp : MonoBehaviour {
	float getspeed=PlayerMovement.speed; 					//accede au variable dun autre script(PlayerMovement)
	float getattactForce=PlayerMovement.attactForce;		//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
	float gettimeBetweenAttacks=PlayerMovement.timeBetweenAttacks;
	float quelPowerUp;
	float nPowerup = 2.0F;

	float tempsActivation = 0.0f; 
	bool estActif = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			other.gameObject.SetActive(false);
			tempsActivation +=10.0f;
			quelPowerUp = Random.Range(0,nPowerup); // 0 est inclu, nPowerUp est exclus
			if(estActif == true){
				tempsActivation += 10.0f;
			}
			else {
				if (quelPowerUp < 1f ){ // grossit le Player
					transform.localScale += new Vector3 (4.0F, 4.0F, 4.0F); 
					transform.rigidbody.mass *= 2.5f; 
					PlayerMovement.speed /=1.35F;
					PlayerMovement.attactForce *=2F;
				}
				else { //quelPowerUp >= 1 pour linstant) // rapetisse le Player
					transform.localScale -= new Vector3 (2.0F, 2.0F, 2.0F); 
					transform.rigidbody.mass /= 1.5f; 
					PlayerMovement.speed *=1.35F;
					PlayerMovement.timeBetweenAttacks *=1.35F;
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
			estActif = false;
			tempsActivation = 0.0f;
			transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F); 
			transform.rigidbody.mass = 6f; 
			PlayerMovement.speed =8F;
			PlayerMovement.attactForce =50.0f;
			PlayerMovement.timeBetweenAttacks =0.88f;

		}
	}



}
