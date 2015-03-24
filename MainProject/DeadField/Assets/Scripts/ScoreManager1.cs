using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager1 : MonoBehaviour
{
	public static int scoreP1;

	GameObject player1;
	Text text;
		
	void Awake ()
	{
		player1 = GameObject.Find("ToonZombie");
		text = GetComponent <Text> ();
		scoreP1 = 0;
	}
	
	void Update ()
	{
		if (player1 != null)
			text.text = "Kills: " + scoreP1;
		else
			text.text = "Dead!";
	}
}