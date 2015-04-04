using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 1;
	public Transform[] path;
	public float startingDelay = 1;
	Vector3 direction;
	int pointNumber;
	bool moving = false;
	float sensitivity = 0.05f;
	
	void Start () {
		Invoke ("StartMoving", startingDelay);
		transform.position = path [0].position;
	}
	
	void StartMoving () {
		moving = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		// kun tarpeeksi aikaa kulunut, kameran liike alkaa
		//		if (Time.timeSinceLevelLoad >= startingDelay) {
		//			moving = true;
		//		}
		
		if (moving == true) {
			// kun saavutetaan viimeinen piste, pysäytetään kamera
			if (Vector3.Distance(transform.position, path[path.Length - 1].position) <= sensitivity) {
				Destroy(this);
				return;
			}
			
			//etsitään vektorien välinen suunta kun ollaan tarpeeksi lähellä seuraavaa käännöspistettä
			if (Vector3.Distance(transform.position, path[pointNumber].position) <= sensitivity) {
				direction = path[pointNumber+1].position - path[pointNumber].position;
				direction.Normalize();
				pointNumber++;
				transform.LookAt(path[pointNumber], Vector3.up);
			}
			
			//liikutaan haluttuun suuntaan
			transform.position += direction * Time.deltaTime * speed;
		}
	}
}
