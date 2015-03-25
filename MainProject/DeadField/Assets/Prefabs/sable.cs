using UnityEngine;
using System.Collections;

public class sable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "sable") {
			PlayerMovement2.speed = 2.5F;
		} 
		else if (prendrePowerUp2.estGros == false && prendrePowerUp2.estPetit == false) {
			PlayerMovement2.speed = 8.0F;
		}
	}
}
