using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour {
	 public AudioClip Sound;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			audio.Play ();
	}
}