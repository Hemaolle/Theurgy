using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float interval;
	public Transform[] path;

	public Wave[] waves;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 0, interval);
	}

	void SpawnEnemy(GameObject enemy) {
		EnemyMovement enemyMovement = (Instantiate (enemy, transform.position, Quaternion.identity) 
		                               as GameObject).GetComponent<EnemyMovement> ();
		enemyMovement.path = path;
	}

	void RunWave(Wave wave) {
		for (int i = 0; i < wave.numberOfEnemies; i++) {
			SpawnEnemy(wave.enemy);
		}
	}
}
