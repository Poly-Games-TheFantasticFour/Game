using UnityEngine;
using System.Collections;

public class prendrePowerUp : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			other.gameObject.SetActive(false);
		}

	}




}
