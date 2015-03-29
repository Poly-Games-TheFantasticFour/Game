using UnityEngine;
using System.Collections;

public class GUImanager : MonoBehaviour {
	
	public GameObject loadingImage;
	public Animator startButton;
	public Animator settingsButton;
	public Animator deathCageButton;
	public Animator exitButton;
	public Animator returnButton;


	public void OpenSettings()

	{
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden",true);
		exitButton.SetBool("isHidden",true);
		returnButton.SetBool ("isHidden", true);
		audio.Play ();


	}

	public void openGameSelection()

	{
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden",true);
		exitButton.SetBool("isHidden",true);
		deathCageButton.SetBool ("isHidden", true);
		returnButton.SetBool ("isHidden", true);
		audio.Play ();


	}

	public void returnSelection() { 
	
	
		startButton.SetBool("isHidden", false);
		settingsButton.SetBool("isHidden",false);
		exitButton.SetBool("isHidden",false);
		deathCageButton.SetBool ("isHidden", false);
		returnButton.SetBool ("isHidden", false);
	
	}

	public void LoadScene(int level)
	{
		loadingImage.SetActive(true);
		Application.LoadLevel(level);
	}

	public void ApplicationQuit (){

		Application.Quit ();

	}
}


