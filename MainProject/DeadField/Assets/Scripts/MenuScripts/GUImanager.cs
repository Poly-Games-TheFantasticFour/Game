using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUImanager : MonoBehaviour {
	
	public GameObject loadingImage;
	public Animator mainButtons;
	public Animator levelSelector;
	public Animator returnButton;
	public Animator nombreDeJoueur;
	public static int njoueur;
	public GameObject cage_button;
	public GameObject runner_button;
	public Animator credit;


	void Awake()
	{
		mainButtons.SetBool ("IsOnScreen", true);
		credit.SetBool("IsOnScreen", false);
	}

	public void OpenSettings()

	{
		mainButtons.SetBool ("IsOnScreen", false);
		returnButton.SetBool ("IsOnScreen", true);
		credit.SetBool("IsOnScreen", true);
		GetComponent<AudioSource>().Play ();
	}

	public void openGameSelection()

	{
		nombreDeJoueur.SetBool("IsOnScreen", false);
		levelSelector.SetBool("IsOnScreen", true);
		GetComponent<AudioSource>().Play ();
	}

	public void nJoueur(){
		nombreDeJoueur.SetBool("IsOnScreen", true);
		mainButtons.SetBool ("IsOnScreen", false);
		returnButton.SetBool ("IsOnScreen", true);
		GetComponent<AudioSource>().Play ();
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
		credit.SetBool ("IsOnScreen", false);
	}

	public void LoadScene(string level)
	{
		cage_button.SetActive(false);
		runner_button.SetActive(false);
		loadingImage.SetActive(true);
        SceneManager.LoadScene(level);
	}

	public void ApplicationQuit (){

		Application.Quit ();

	}





}


