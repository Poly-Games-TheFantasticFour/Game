using UnityEngine;
using System.Collections;


public class prendrePowerUp : MonoBehaviour {

	float tempsActivation = 0.0f; 
	bool estActif = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "powerUp") {
			other.gameObject.SetActive(false);
			tempsActivation +=10.0f;
			if(estActif == true){
				tempsActivation += 10.0f;
			}
			else {
				transform.localScale += new Vector3 (3.0F, 3.0F, 3.0F); 
			}
			StartCoroutine (actif());
		}
	}

	IEnumerator actif(){
	
		estActif = true;
		float time = 0;
		while (time < (tempsActivation * Time.deltaTime)) {
			time += Time.deltaTime;
			yield return new WaitForSeconds(1.0F);
		}
		if (time >= (tempsActivation * Time.deltaTime)) {
			estActif = false;
			tempsActivation = 0.0f;
			transform.localScale -= new Vector3 (3.0F,3.0F,3.0F);

		}
	}



}
