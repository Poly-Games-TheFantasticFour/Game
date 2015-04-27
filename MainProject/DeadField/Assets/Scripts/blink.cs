using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour {

	public const float BLINK_TIME = 1.0f;
	//public AudioClip shutdownClip;
	//public AudioClip startClip;


	void Awake () 
	{
		StartCoroutine (laserBlink());
	}
	// Update is called once per frame
	IEnumerator laserBlink () {
		yield return new WaitForSeconds (1.3f);
		//audio.clip = shutdownClip;
		//audio.Play ();
		float timeFinish = Time.time + BLINK_TIME;
		//WaitForSeconds (0.2);
		while (Time.time < timeFinish) {
			yield return new WaitForSeconds(Random.value/10);
			if(gameObject.renderer != null)
			gameObject.renderer.enabled = !gameObject.renderer.enabled;
		}
		//audio.clip = startClip;
		//audio.Play ();
		gameObject.renderer.enabled = false;
	}
}
