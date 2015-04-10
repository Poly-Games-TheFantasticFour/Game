using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "DeathZone")
			Destroy (other.gameObject);
	}
}
