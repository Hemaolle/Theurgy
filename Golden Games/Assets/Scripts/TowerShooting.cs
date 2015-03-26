﻿using UnityEngine;
using System.Collections;

public class TowerShooting : MonoBehaviour {

	public GameObject bullet;

	public float shootInterval;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Shoot", shootInterval, shootInterval);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot() {
		GameObject newBullet = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
		newBullet.GetComponent<Projectile> ().target = GameObject.FindWithTag ("Enemy");
	}
}
