using UnityEngine;
using System.Collections;

public class Attack1 : MonoBehaviour {

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

	void FixedUpdate () 
	{
		timer += Time.deltaTime;

		//Attack on button use if player is not stunned, minimum time between each attack based on timer. Play attack animation.
		if (!stunt1.estStrunt1 && Input.GetButtonDown("AttackP1")&& timer >= timeBetweenAttacks && Time.timeScale != 0) 
		{
			timer = 0.0f;
			anim.SetTrigger ("Attack");
			Invoke("Attack", .5f);
		}
	}

	void Attack()
	{
		//Vecteur en direction de l'endroit ou regarde le joueur.
		Vector3 DirectionRay = transform.TransformDirection (Vector3.forward);						
		
		//Apply force if ennemy player in range during attack.
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
	//True when a ennemy player enter the attack range trigger collider.
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player2") || other.gameObject.layer == LayerMask.NameToLayer("Player3") || other.gameObject.layer == LayerMask.NameToLayer("Player4")) {
			ennemy = other;
			isInRange = true;
		}
	}
	//False when a ennemy player enter the attack range trigger collider.
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player2") || other.gameObject.layer == LayerMask.NameToLayer("Player3") || other.gameObject.layer == LayerMask.NameToLayer("Player4")) {
			isInRange = false;
		}
	}
}
