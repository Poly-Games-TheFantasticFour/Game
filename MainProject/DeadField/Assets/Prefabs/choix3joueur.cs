using UnityEngine;
using System.Collections;

public class choix3joueur : MonoBehaviour {

	// Use this for initialization
		void Start () {
			if (GUImanager.njoueur == 3) {
				Destroy (gameObject);
			}
		}
		
	}
