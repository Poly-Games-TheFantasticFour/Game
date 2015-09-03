using UnityEngine;
using System.Collections;


public class prendrePowerUp4 : MonoBehaviour {
	
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
		halo = GameObject.Find("skin").GetComponent("Halo");
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
		Attack1.attaque = false;
		estGros = true;
		estPetit = estGlow  = false;
		
		transform.localScale = new Vector3 (4.0F, 4.0F, 4.0F); 
		transform.GetComponent<Rigidbody>().mass = 8F; 
		PlayerMovement4.speed = 6.0F;					//http://answers.unity3d.com/questions/400977/changing-a-variable-in-one-script-using-another-sc.html
		Attack4.attactForce = 100.0F;
		Attack4.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGros)
			normal ();
	}
	
	IEnumerator petit (){
		estPetit = true;
		estGros = estGlow = false;
		
		transform.localScale = new Vector3 (1.25F, 1.25F, 1.25F); 
		transform.GetComponent<Rigidbody>().mass = 5f; 
		PlayerMovement4.speed = 10F;
		Attack4.timeBetweenAttacks = 0.40F;
		Attack4.attactForce = 75.0f;
		
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
		PlayerMovement4.speed = 8F;
		Attack4.attactForce = 100.0f;;
		Attack4.timeBetweenAttacks = 0.88f;
		transform.localScale = new Vector3 (2.25F, 2.25F, 2.25F);
		
		halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
		
		yield return new WaitForSeconds (tempsActivation);
		if (estGlow)
			normal ();
	}
	
	void normal(){
		estGros = estPetit = estGlow = false;
		transform.localScale = new Vector3 (2.25F, 2.25F, 2.25F); 
		transform.GetComponent<Rigidbody>().mass = 6f; 
		PlayerMovement4.speed = 8F;
		Attack4.attactForce = 100.0f;
		Attack4.timeBetweenAttacks = 0.88f;
		
		halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
