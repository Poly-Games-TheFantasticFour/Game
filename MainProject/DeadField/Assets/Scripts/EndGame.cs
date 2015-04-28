using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {

	public GameObject player1, player2, player3, player4, endHud;
	public Text textWin, textRestart;
	bool isEnded = false;
	
	//bool isAliveP1 = true;
	//bool isAliveP2 = true;
	//Animator animP1, animP2;
	
	void Update () 
	{
		//Score ();
		
		if (player1 != null && player2 == null && player3 == null && player4 == null){
			textWin.text = "Zombie wins";
			Restart();
		}
		if (player1 == null && player2 != null && player3 == null && player4 == null){
			textWin.text = "Monster wins";
			Restart();
		}
		if (player1 == null && player2 == null && player3 != null && player4 == null){
			textWin.text = "Knight wins";
			Restart();
		}
		if (player1 == null && player2 == null && player3 == null && player4 != null){
			textWin.text = "Skeleton wins";
			Restart();
		}

		if (isEnded && Input.GetKeyDown (KeyCode.M)) {
			endHud.SetActive(false);
			Application.LoadLevel ("MenuScreen");
		}
		if (isEnded && Input.GetKeyDown (KeyCode.R)) {
			endHud.SetActive(false);
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	
	void Restart()
	{
		textRestart.text = "Press 'M' to return to menu or 'R' to restart";
		endHud.SetActive(true);
		isEnded = true;
	}
	
	/*void Score()
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
	}*/
}
