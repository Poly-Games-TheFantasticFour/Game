using UnityEngine;
using System.Collections;

public class GUImanager : MonoBehaviour {
	
	public GameObject loadingImage;
	public Animator startButton;
	public Animator settingsButton;
	public Animator deathCageButton;
	public Animator exitButton;
	public Animator returnButton;
	public Animator nombreDeJoueur;
	public Animator joueur_4; 
	public Animator joueur_3; 
	public Animator joueur_2; 
	public static int njoueur;

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
		nombreDeJoueur.SetBool("isHidden", false);
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden",true);
		exitButton.SetBool("isHidden",true);
		deathCageButton.SetBool ("isHidden", true);
		returnButton.SetBool ("isHidden", true);
		audio.Play ();


	}

	public void nJoueur(){
		nombreDeJoueur.SetBool("isHidden", true);
		startButton.SetBool("isHidden", true);
		settingsButton.SetBool("isHidden",true);
		exitButton.SetBool("isHidden",true);
		returnButton.SetBool ("isHidden", true);
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
	
		nombreDeJoueur.SetBool("isHidden", false);
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


