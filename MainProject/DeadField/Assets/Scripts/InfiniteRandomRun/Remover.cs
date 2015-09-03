using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour {

	public float timeBeforeFalling = 0.75f;
	public float timeBeforeDestroy = 3.0f;

	void OnTriggerEnter(Collider other)
	{ 
		if (other.gameObject.layer == LayerMask.NameToLayer ("Jump"))
		{
			other.gameObject.GetComponent<Renderer>().material.color = Color.white;
			StartCoroutine (Fall (other));
		}
	}

	IEnumerator Fall(Collider other)
	{
		yield return new WaitForSeconds (Random.Range(0f,timeBeforeFalling));
		other.GetComponent<Rigidbody>().useGravity = true;
		other.GetComponent<Rigidbody>().isKinematic = false;
	}
}
