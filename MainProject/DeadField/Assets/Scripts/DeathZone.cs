using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
	}
}
