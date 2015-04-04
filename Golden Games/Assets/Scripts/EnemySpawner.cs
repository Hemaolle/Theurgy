using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float interval;
	public Transform[] path;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 0, interval);
	}

	void SpawnEnemy() {
		EnemyMovement enemyMovement = (Instantiate (enemy, transform.position, Quaternion.identity) 
		                               as GameObject).GetComponent<EnemyMovement> ();
		enemyMovement.path = path;
	}
}
