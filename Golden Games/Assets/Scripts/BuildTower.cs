using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {

	public GameObject tower;

	public void Build() {
		Instantiate(tower, Vector3.zero, Quaternion.identity);
		//GameObject newTower = Instantiate(tower, Vector3.zero, Quaternion.identity) as GameObject;
		//newTower.GetComponent<TowerPlacement>().tower = newTower;
	}
}
