using UnityEngine;
using System.Collections;

public class Attack2 : MonoBehaviour {
	
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
		
		if (!stunt2.estStrunt2 && Input.GetButtonDown("AttackP2") && timer >= timeBetweenAttacks && Time.timeScale != 0) 
		{
			timer = 0.0f;
			anim.SetTrigger ("Attack");
			Invoke("Attack", .4f);
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
		if (other.gameObject.layer == LayerMask.NameToLayer("Player1") || other.gameObject.layer == LayerMask.NameToLayer("Player3") || other.gameObject.layer == LayerMask.NameToLayer("Player4")) {
			ennemy = other;
			isInRange = true;
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player1") || other.gameObject.layer == LayerMask.NameToLayer("Player3") || other.gameObject.layer == LayerMask.NameToLayer("Player4")) {
			isInRange = false;
		}
	}
}
