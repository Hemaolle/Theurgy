using UnityEngine;
using System.Collections;

public class TowerShooting : MonoBehaviour {

	public GameObject bullet;
	public GameObject shootingPosition;
	public float shootInterval;
	public float maxRange = 4;

	private GameObject target;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Shoot", shootInterval, shootInterval);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot() {
		if (target == null || Vector3.Distance (target.transform.position, transform.position) > maxRange) {
			target = FindClosestWithTag ("Enemy");
		}
		// TODO: should maybe start shooting immediately when enemy gets close enough, now only checks between shootInterval times
		if (Vector3.Distance (transform.position, FindClosestWithTag ("Enemy").transform.position) < maxRange) {
			GameObject newBullet = Instantiate (bullet, shootingPosition.transform.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<Projectile> ().target = target;
		}
	}

	GameObject FindClosestWithTag(string tag) {
		GameObject closestSoFar = null;
		float closestDistance = float.MaxValue;
		foreach (GameObject candidate in GameObject.FindGameObjectsWithTag(tag)) {
			float candidateDistance = Vector3.Distance(transform.position, candidate.transform.position);
			if (candidateDistance < closestDistance) {
				closestSoFar = candidate;
				closestDistance = candidateDistance;
			}
		}
		return closestSoFar;
	}
}
