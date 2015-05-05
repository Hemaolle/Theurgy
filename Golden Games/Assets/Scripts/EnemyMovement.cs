using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 1;
	public float rotationSpeed = 1;
	public Transform[] path;
	int pointNumber;
	
	void Start () {
		transform.position = path [0].position;
		transform.rotation = Quaternion.LookRotation (path [pointNumber + 1].position - path [pointNumber].position, Vector3.up);
		MoveToNextPoint ();
	}

	void RotateToNextDirection() {
		if (pointNumber < path.Length - 1) {
			Quaternion newRotation = Quaternion.LookRotation (path [pointNumber + 1].position - path [pointNumber].position, Vector3.up);
			Vector3 newRotationEuler = newRotation.eulerAngles;
			iTween.RotateTo (gameObject, iTween.Hash ("x", newRotationEuler.x,
		                "y", newRotationEuler.y,
		                "z", newRotationEuler.z,
		                "speed", rotationSpeed,
		                "easetype", iTween.EaseType.linear,
		                "oncomplete", "MoveToNextPoint"));
		}
	}

	void MoveToNextPoint() {
		pointNumber++;
		if (pointNumber == path.Length - 1) {
			DamageCore();
		}
		if (pointNumber < path.Length) {
			iTween.MoveTo (gameObject, iTween.Hash ("x", path [pointNumber].position.x,
		                                      "y", path [pointNumber].position.y,
		                                      "z", path [pointNumber].position.z,
		                                      "speed", speed,
		                                      "easetype", iTween.EaseType.linear,
		                                      "oncomplete", "RotateToNextDirection"));
		}
	}

	void DamageCore() {
		CoreHealthbar.Get ().GetComponent<EnemyHealth> ().TakeDamage (1);
	}
}
