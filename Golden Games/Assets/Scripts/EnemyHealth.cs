using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 10;
	public Slider healthSlider;

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
			Destroy (gameObject);
		}
	}
}
