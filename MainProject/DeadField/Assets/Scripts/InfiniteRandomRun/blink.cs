using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour {

	public float blinkTime = 1.0f;
	public float timeBeforeBlink = 0.3f;
	
	//public AudioClip shutdownClip;
	//public AudioClip startClip;


	void Awake () 
	{
		StartCoroutine (laserBlink());
	}

	IEnumerator laserBlink () {
		yield return new WaitForSeconds (timeBeforeBlink);
		//audio.clip = shutdownClip;
		float timeFinish = Time.time + blinkTime;
		while (Time.time < timeFinish) {
			yield return new WaitForSeconds(Random.value/10);
				gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
			}
		//audio.clip = startClip;
		//audio.Play ();
		gameObject.GetComponent<Renderer>().enabled = false;
	}
}

