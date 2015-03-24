using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager2 : MonoBehaviour {

	public static int scoreP2;
	
	GameObject player2;
	Text text;
	
	void Awake ()
	{
		player2 = GameObject.Find("Monster");
		text = GetComponent <Text> ();
		scoreP2 = 0;
	}
	
	void Update ()
	{
		if (player2 != null)
			text.text = "Kills: " + scoreP2;
		else
			text.text = "Dead!";
	}
}