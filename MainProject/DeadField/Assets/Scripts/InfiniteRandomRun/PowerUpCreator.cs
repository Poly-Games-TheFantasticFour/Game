using UnityEngine;
using System.Collections;

public class PowerUpCreator : MonoBehaviour {

	public GameObject powerUp;
	public float timeBeforeSpawning = 3.5f;
	public float SpawnMinTime = 1f;
	public float SpawnMaxTime = 3f;
	
	void Start () 
	{
		Invoke ("Spawn", timeBeforeSpawning);
	}

	
	void Spawn()
	{
		Instantiate (powerUp, transform.position - (17.5f * Vector3.right) + new Vector3(Random.Range(0,7)*5,0,0), Quaternion.identity);
		Invoke ("Spawn", Random.Range (SpawnMinTime, SpawnMaxTime));
	}
}