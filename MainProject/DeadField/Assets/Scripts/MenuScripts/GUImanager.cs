using UnityEngine;
using System.Collections;

public class GUImanager : MonoBehaviour {
	
	public GameObject loadingImage;
	public Animator mainButtons;
	public Animator levelSelector;
	public Animator returnButton;
	public Animator nombreDeJoueur;
	public static int njoueur;
	public GameObject cage_button;
	public GameObject runner_button;


	void Awake()
	{
		mainButtons.SetBool ("IsOnScreen", true);
	}

	public void OpenSettings()

	{
		mainButtons.SetBool ("IsOnScreen", false);
		returnButton.SetBool ("IsOnScreen", true);
		audio.Play ();
	}

	public void openGameSelection()

	{
		nombreDeJoueur.SetBool("IsOnScreen", false);
		levelSelector.SetBool("IsOnScreen", true);
		audio.Play ();
	}

	public void nJoueur(){
		nombreDeJoueur.SetBool("IsOnScreen", true);
		mainButtons.SetBool ("IsOnScreen", false);
		returnButton.SetBool ("IsOnScreen", true);
		audio.Play ();
	}

	public void joueur4(){
		njoueur = 4;
		openGameSelection ();
	}
	public void joueur3(){
		njoueur = 3;
		openGameSelection ();
	}

	public void joueur2(){
		njoueur = 2;
		openGameSelection ();
	}

	public void returnSelection() { 
	
		nombreDeJoueur.SetBool("IsOnScreen", false);
		mainButtons.SetBool ("IsOnScreen", true);
		levelSelector.SetBool("IsOnScreen", false);
		returnButton.SetBool ("IsOnScreen", false);
	}

	public void LoadScene(string level)
	{
		cage_button.SetActive(false);
		runner_button.SetActive(false);
		loadingImage.SetActive(true);
		Application.LoadLevel(level);
	}

	public void ApplicationQuit (){

		Application.Quit ();

	}





}


