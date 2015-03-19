using UnityEngine;
using System.Collections;


public class prendrePowerUp : MonoBehaviour {

	float getspeed = PlayerMovement.speed; 					//accede au variable dun autre script(PlayerMovement)
	float getattactForce = PlayerMovement.attactForce;		//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
	float gettimeBetweenAttacks = PlayerMovement.timeBetweenAttacks;
	float quelPowerUp;
	float nPowerup = 3.0f;
	public static bool estGros = false;

	float tempsActivation = 0.0f;
	Component halo;

	void Start()
	{
		halo = GameObject.Find("eye").GetComponent("Halo");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			other.gameObject.SetActive(false);
			tempsActivation = 10.0f;
			quelPowerUp = Random.Range(0f,nPowerup); // 0 est inclu, nPowerUp est exclus
			tempsActivation = 10.0f;
			if (quelPowerUp < 1f ){ // grossit le Player
				grossir();
			}
			if (quelPowerUp >= 1f && quelPowerUp < 2f){ //quelPowerUp >= 1 pour linstant) // rapetisse le Player
				petit(); 
			}
			if (quelPowerUp >= 2f ){
				glow (); 
			}
			StartCoroutine (actif());
		}
	}

	IEnumerator actif(){
	
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
		PlayerMovement.speed = 6.0F;
		PlayerMovement.attactForce = 100.0F;
		PlayerMovement.timeBetweenAttacks = 0.88f;

		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	void petit (){
		estGros = false;
		transform.localScale = new Vector3 (2.8F, 2.8F, 2.8F); 
		transform.rigidbody.mass = 5f; 
		PlayerMovement.speed = 10F;
		PlayerMovement.timeBetweenAttacks = 0.40F;
		PlayerMovement.attactForce = 50.0f;

		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	void glow(){
		estGros = false;
		transform.rigidbody.mass = 6f; 
		PlayerMovement.speed = 8F;
		PlayerMovement.attactForce = 75.0f;
		PlayerMovement.timeBetweenAttacks = 0.88f;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F);

		halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
	}

	void normal(){
		estGros = false;
		tempsActivation = 0.0f;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F); 
		transform.rigidbody.mass = 6f; 
		PlayerMovement.speed = 8F;
		PlayerMovement.attactForce = 75.0f;
		PlayerMovement.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
