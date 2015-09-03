using UnityEngine;
using System.Collections;


public class prendrePowerUp1 : MonoBehaviour {
	
	public static bool estGros = false;
	public float tempsActivation = 10.0f;
	
	int quelPowerUp;
	int actif = -1;
	int nPowerup = 3;
	bool estPetit = false;
	bool estGlow = false;
	
	Component halo;
	
	void Awake()
	{
		halo = GameObject.Find("eye").GetComponent("Halo");
		normal();
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Destroy powerUp when player enters in contact
		if (other.gameObject.tag == "powerUp") {
			Destroy (other.gameObject);
			
			//Randomize the powerup and apply to player.
			do{
				quelPowerUp = Random.Range(0,nPowerup); // 0 est inclu, nPowerUp est exclus
			}while(quelPowerUp == actif);
			
			switch(quelPowerUp)
			{
			case 0: actif = 0; StartCoroutine (grossir());
				break;
			case 1: actif = 1; StartCoroutine (petit());
				break;
			case 2: actif = 2; StartCoroutine (glow ());
				break;
			}
		}
	}

	//Allow the player to grow in size, stun on attack. Cause the player to walk slower and jump lower. Reset all properties after activation time.
	IEnumerator grossir(){
		Attack1.attaque = false;
		estGros = true;
		estPetit = estGlow  = false;
		
		transform.localScale = new Vector3 (10.0F, 10.0F, 10.0F); 
		transform.GetComponent<Rigidbody>().mass = 8F; 
		PlayerMovement1.speed = 6.0F;					//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
		Attack1.attactForce = 100.0F;
		Attack1.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGros)
			normal ();
	}

	//Allow the player to reduce its size, run faster et jump higher. Cause the player receive more knockback on hit. Reset all properties after activation time.
	IEnumerator petit (){
		estPetit = true;
		estGros = estGlow = false;
		
		transform.localScale = new Vector3 (2.8F, 2.8F, 2.8F); 
		transform.GetComponent<Rigidbody>().mass = 5f; 
		PlayerMovement1.speed = 10F;
		Attack1.timeBetweenAttacks = 0.40F;
		Attack1.attactForce = 75.0f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estPetit)
			normal ();
	}

	//Allow the player to float on current height. Negate jump function while in use. Reset all properties after activation time.
	IEnumerator glow(){
		estGlow = true;
		estPetit = estGros = false;
		
		transform.GetComponent<Rigidbody>().mass = 6f; 
		PlayerMovement1.speed = 8F;
		Attack1.attactForce = 100.0f;;
		Attack1.timeBetweenAttacks = 0.88f;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F);
		
		halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGlow)
			normal ();
	}

	//Reset all normal properties..
	void normal(){
		estGros = estPetit = estGlow = false;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F); 
		transform.GetComponent<Rigidbody>().mass = 6f; 
		PlayerMovement1.speed = 8F;
		Attack1.attactForce = 100.0f;
		Attack1.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
