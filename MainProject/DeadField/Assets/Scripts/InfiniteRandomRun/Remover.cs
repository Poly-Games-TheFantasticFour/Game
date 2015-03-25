using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour {

	public float timeBeforeFalling = 0.75f;
	public float timeBeforeDestroy = 3.0f;

	void OnTriggerEnter(Collider other)
	{ 
		if (other.gameObject.layer == LayerMask.NameToLayer ("Jump"))
		{
			other.gameObject.renderer.material.color = Color.white;
			StartCoroutine (Fall (other));
		}
	}

	IEnumerator Fall(Collider other)
	{
		yield return new WaitForSeconds (Random.Range(0f,timeBeforeFalling));
		other.rigidbody.useGravity = true;
		other.rigidbody.isKinematic = false;
	}
}
