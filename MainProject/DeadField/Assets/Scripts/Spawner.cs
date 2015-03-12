using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject powerUp;
	public float premierSpawn = 3f;
	public float intervalleEntreSpawn = 3f;


	void Start () {
			InvokeRepeating("spawn", premierSpawn /*temps avant 1er spawn*/ , intervalleEntreSpawn /*intervalle entre les spawns*/);
	}
	

	void spawn () 
	{
		 {
			Vector3 spawnPoint = new Vector3 (Random.Range (0F, 35F), 2.5F, Random.Range (0F, 35.0F)); 
			Instantiate (powerUp, spawnPoint/*endroit*/, transform.rotation);
		} 

	}
}
