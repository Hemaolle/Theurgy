using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildTower : MonoBehaviour {

	public GameObject tower;

	int price;

	private Button buildButton;

	void Start() {
		buildButton = GetComponent<Button> ();
		price = tower.GetComponent<TowerPlacement> ().price;
	}


	void Update() {
		// TODO: optimization: Subscribe to Resources and make this update only when resources change.
		if (!Resources.CanAfford (price)) {
			buildButton.interactable = false;
		} else {
			buildButton.interactable = true;
		}
	}

	public void Build() {
		Instantiate(tower, Vector3.zero, Quaternion.identity);
		//GameObject newTower = Instantiate(tower, Vector3.zero, Quaternion.identity) as GameObject;
		//newTower.GetComponent<TowerPlacement>().tower = newTower;
	}
}
