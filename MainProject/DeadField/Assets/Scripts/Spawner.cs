using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject powerUp;
	public float premierSpawn = 4.0f;
	public float intervalle = 15F;
	

	void Start () {
		InvokeRepeating("spawn", premierSpawn /*temps avant 1er spawn*/ , intervalle /*intervalle entre les spawns*/);
	}
	

	void spawn () 
	{
		 {
			Vector3 spawnPoint = new Vector3 (Random.Range (0F, 35F), 2.0F, Random.Range (0F, 35.0F)); 
			Instantiate (powerUp, spawnPoint/*endroit*/, transform.rotation);
		} 

	}
}
