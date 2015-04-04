using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject target;
	public float damage = 1;
	public float speed = 5;

	Vector3 targetLocation;
	bool targetAlive = true;

	// Use this for initialization
	void Start () {
		targetLocation = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			targetAlive = false;
			iTween.MoveTo(gameObject, iTween.Hash("x", targetLocation.x,
			                                      "y", targetLocation.y,
			                                      "z", targetLocation.z,
			                                      "speed", speed,
			                                      "easetype", iTween.EaseType.linear,
			                                      "oncomplete", "DestroyThis"));
		}
		if (targetAlive) {
			Vector3 direction = target.transform.position - transform.position;
			direction.Normalize ();
			transform.position += direction * Time.deltaTime * speed;
		}

	}

	void DestroyThis() {
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log (collider.name);
		if (collider.tag == "Enemy") {
			collider.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
			Destroy (gameObject);
		}
	}
}
