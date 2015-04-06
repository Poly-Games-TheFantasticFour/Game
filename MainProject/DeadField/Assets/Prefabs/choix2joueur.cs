using UnityEngine;
using System.Collections;

public class choix2joueur : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GUImanager.njoueur == 3 || GUImanager.njoueur == 2) {
			Destroy (gameObject);
		}
	}
	
}
