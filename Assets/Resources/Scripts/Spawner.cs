using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float rate;
	public GameObject[] enemies;
	public int enemiesPerWave = 1;


	void Start () {
		InvokeRepeating ("SpawnEnemy", rate, rate);
	}
	
	void SpawnEnemy () {
		for (int i = 0; i < enemiesPerWave; i++) {
			Instantiate (enemies [(int)Random.Range (0, enemies.Length)], new Vector2 (Random.Range (-8f, 8f), 7f), Quaternion.identity);
		}
	}
}
