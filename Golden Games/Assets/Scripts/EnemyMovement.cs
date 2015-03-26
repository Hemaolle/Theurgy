using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 1;
	public Transform[] cameraPoints;
	public float startingDelay = 1;
	Vector3 direction;
	int pointNumber;
	bool moving = false;
	float sensitivity = 0.05f;
	
	void Start () {
		Invoke ("StartMoving", startingDelay);
		transform.position = cameraPoints [0].position;
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
			if (Vector3.Distance(transform.position, cameraPoints[cameraPoints.Length - 1].position) <= sensitivity) {
				Destroy(this);
				return;
			}
			
			//etsitään vektorien välinen suunta kun ollaan tarpeeksi lähellä seuraavaa käännöspistettä
			if (Vector3.Distance(transform.position, cameraPoints[pointNumber].position) <= sensitivity) {
				direction = cameraPoints[pointNumber+1].position - cameraPoints[pointNumber].position;
				direction.Normalize();
				pointNumber++;
				transform.LookAt(cameraPoints[pointNumber], Vector3.up);
			}
			
			//liikutaan haluttuun suuntaan
			transform.position += direction * Time.deltaTime * speed;
		}
	}
}
