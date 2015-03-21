using UnityEngine;
using System.Collections;


public class prendrePowerUp : MonoBehaviour {

	public static bool estGros = false;
	public float tempsActivation = 10.0f;

	int quelPowerUp;
	int actif = -1;
	int nPowerup = 3;
	bool estPetit = false;
	bool estGlow = false;
	Component halo;

	void Start()
	{
		halo = GameObject.Find("eye").GetComponent("Halo");
		normal();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			Destroy (other.gameObject);

			do{
				quelPowerUp = Random.Range(0,nPowerup); // 0 est inclu, nPowerUp est exclus
			}while(quelPowerUp == actif);

			switch(quelPowerUp)
			{
			case 0: StartCoroutine (grossir()); actif = 0;
				break;
			case 1: StartCoroutine (petit()); actif = 1;
				break;
			case 2: StartCoroutine (glow ()); actif = 2;
				break;
			}
		}
	}
	
	IEnumerator grossir(){
		PlayerMovement.attaque = false;
		estGros = true;
		estPetit = estGlow  = false;

		transform.localScale = new Vector3 (10F, 10F, 10F); 
		transform.rigidbody.mass = 9.5F; 
		PlayerMovement.speed = 6.0F;					//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
		PlayerMovement.attactForce = 100.0F;
		PlayerMovement.timeBetweenAttacks = 0.88f;

		halo.GetType().GetProperty ("enabled").SetValue (halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		yield return new WaitForSeconds (tempsActivation);
		if (estGros)
			normal ();
	}

	IEnumerator petit (){
		estPetit = true;
		estGros = estGlow = false;

		transform.localScale = new Vector3 (2.8F, 2.8F, 2.8F); 
		transform.rigidbody.mass = 5f; 
		PlayerMovement.speed = 10F;
		PlayerMovement.timeBetweenAttacks = 0.40F;
		PlayerMovement.attactForce = 50.0f;

		halo.GetType().GetProperty ("enabled").SetValue (halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		yield return new WaitForSeconds (tempsActivation);
		if (estPetit)
			normal ();
	}

	IEnumerator glow(){
		estGlow = true;
		estPetit = estGros = false;

		transform.rigidbody.mass = 6f; 
		PlayerMovement.speed = 8F;
		PlayerMovement.attactForce = 75.0f;
		PlayerMovement.timeBetweenAttacks = 0.88f;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F);

		halo.GetType().GetProperty ("enabled").SetValue (halo, true, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

		yield return new WaitForSeconds (tempsActivation);
		if (estGlow)
			normal ();
	}

	void normal(){
		estGros = estPetit = estGlow = false;
		transform.localScale = new Vector3 (5.0F, 5.0F, 5.0F); 
		transform.rigidbody.mass = 6f; 
		PlayerMovement.speed = 8F;
		PlayerMovement.attactForce = 75.0f;
		PlayerMovement.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
