using UnityEngine;
using System.Collections;

public class Attack4 : MonoBehaviour {

	public static float attactForce = 100.0f;
	public static float timeBetweenAttacks = 0.88f;
	public static bool attaque = false;

	float timer = 0.0f;
	bool isInRange = false;
	
	public AudioClip getHitClip;
	public AudioClip attackClip;
	AudioSource playerSound;
	Animator anim;
	Collider ennemy;
	
	void Awake () 
	{
		anim = GetComponent <Animator> ();
		playerSound = GetComponent <AudioSource> ();

	}

	void Update () 
	{
		timer += Time.deltaTime;

		if (!stunt1.estStrunt1 && Input.GetButtonDown("AttackP4")&& timer >= timeBetweenAttacks && Time.timeScale != 0) 
		{
			timer = 0.0f;
			anim.SetTrigger ("Attack");
			Invoke("Attack", .5f);
		}
	}

	void Attack()
	{
		Vector3 DirectionRay = transform.TransformDirection (Vector3.forward);						//Vecteur en direction de l'endroit ou regarde le joueur.
		
		if (isInRange) {
			ennemy.GetComponent<Rigidbody>().AddForce (DirectionRay.normalized * attactForce, ForceMode.Impulse);
			playerSound.clip = getHitClip;
			attaque = true;
			isInRange = false;
		}
		else
			playerSound.clip = attackClip;
		playerSound.Play ();
	}

	//************************Trigger Related functions*************************
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player1") || other.gameObject.layer == LayerMask.NameToLayer("Player2") || other.gameObject.layer == LayerMask.NameToLayer("Player3")) {
			ennemy = other;
			isInRange = true;
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player1") || other.gameObject.layer == LayerMask.NameToLayer("Player2") || other.gameObject.layer == LayerMask.NameToLayer("Player3")) {
			isInRange = false;
		}
	}
}
