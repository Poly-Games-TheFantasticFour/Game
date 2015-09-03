using UnityEngine;
using System.Collections;


public class prendrePowerUp3 : MonoBehaviour {
	
	public static bool estGros = false;
	public GameObject armArmor;
	public float tempsActivation = 10.0f;
	
	int quelPowerUp;
	int actif = -1;
	int nPowerup = 3;
	bool estPetit = false;
	bool estGlow = false;
	
	Component halo;
	
	void Awake()
	{
		halo = armArmor.GetComponent("Halo");
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
			case 0: actif = 0; StartCoroutine (grossir());
				break;
			case 1: actif = 1; StartCoroutine (petit());
				break;
			case 2: actif = 2; StartCoroutine (glow ());
				break;
			}
		}
	}
	
	IEnumerator grossir(){
		Attack3.attaque = false;
		estGros = true;
		estPetit = estGlow  = false;
		
		transform.localScale = new Vector3 (3.0F, 3.0F, 3.0F); 
		transform.GetComponent<Rigidbody>().mass = 8F; 
		PlayerMovement3.speed = 6.0F;					//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
		Attack3.attactForce = 100.0F;
		Attack3.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGros)
			normal ();
	}
	
	IEnumerator petit (){
		estPetit = true;
		estGros = estGlow = false;
		
		transform.localScale = new Vector3 (1.0F, 1.0F, 1.0F); 
		transform.GetComponent<Rigidbody>().mass = 5f; 
		PlayerMovement3.speed = 10F;
		Attack3.timeBetweenAttacks = 0.40F;
		Attack3.attactForce = 75.0f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estPetit)
			normal ();
	}
	
	IEnumerator glow(){
		estGlow = true;
		estPetit = estGros = false;
		
		transform.GetComponent<Rigidbody>().mass = 6f; 
		PlayerMovement3.speed = 8F;
		Attack3.attactForce = 100.0f;
		Attack3.timeBetweenAttacks = 0.88f;
		transform.localScale = new Vector3 (1.75F, 1.75F, 1.75F);
		
		halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGlow)
			normal ();
	}
	
	void normal(){
		estGros = estPetit = estGlow = false;
		transform.localScale = new Vector3 (1.75F, 1.75F, 1.75F); 
		transform.GetComponent<Rigidbody>().mass = 6f; 
		PlayerMovement3.speed = 8F;
		Attack3.attactForce = 100.0f;
		Attack3.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
