﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 10;
	public Slider healthSlider;
	public int killPrice;
	public GameObject enemyDeathParticle;

	float currentHealth;


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(float damage) {
		currentHealth -= damage;
		healthSlider.value = currentHealth / maxHealth;
		if (currentHealth <= 0) {
			Death();
		}
	}

	protected virtual void Death() {
		Resources.ChangeGoldAmount(killPrice);
		Instantiate (enemyDeathParticle, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
		Destroy (gameObject);
	}
}
