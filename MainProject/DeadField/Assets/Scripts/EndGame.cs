using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public float restartTimer = 2.0f;
	GameObject player1, player2;

	bool isAliveP1 = true;
	bool isAliveP2 = true;
	Animator animP1, animP2;

	void Start () {
		player1 = GameObject.Find("ToonZombie");
		player2 = GameObject.Find ("Monster");
		animP1 = GameObject.Find("ToonZombieImage").GetComponent<Animator>();
		animP2 = GameObject.Find("MonsterImage").GetComponent<Animator>();
	}

	void Update () 
	{
		Score ();

		if (player1 == null && player2 == null)
			Invoke ("Restart", restartTimer);
	}

	void Restart()
	{
		Application.LoadLevel("Arena_Cage");
	}

	void Score()
	{
		if (player1 == null && isAliveP1) {
			ScoreManager2.scoreP2 += 1;
			animP1.SetTrigger ("Fade");
			isAliveP1 = false;
		}
		
		if (player2 == null && isAliveP2) {
			ScoreManager1.scoreP1 += 1;
			animP2.SetTrigger ("Fade");
			isAliveP2 = false;
		}
	}
}
