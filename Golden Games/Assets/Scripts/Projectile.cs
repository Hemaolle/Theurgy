using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject target;

	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = target.transform.position - transform.position;
		direction.Normalize ();
		transform.position += direction * Time.deltaTime * speed;
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log (collider.name);
		if (collider.tag == "Enemy")
			Destroy (gameObject);
	}
}
