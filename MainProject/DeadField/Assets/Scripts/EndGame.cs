using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public float restartTimer = 3.0f;
	GameObject player1, player2;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Zombie");
		player2 = GameObject.Find ("Monster");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player1 == null && player2 == null)
			Invoke ("Restart", restartTimer);
	}

	void Restart(){
		Application.LoadLevel("Arena_Cage");
	}
}
