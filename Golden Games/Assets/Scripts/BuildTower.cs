using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {

	public GameObject tower;



	// Use this for initialization
	void Start () {
	
	}

	private RaycastHit hit;  

	void Update () {
		int groundLayermask = 1 << LayerMask.NameToLayer ("Ground");

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, groundLayermask)) { //&& Input.GetMouseButtonDown (0) && hit.transform.name == "Play"
			tower.transform.position = hit.point;
		}

		if (Input.GetMouseButtonDown (0)) {
			GameObject newTower = Instantiate(tower, hit.point, Quaternion.identity) as GameObject;
			newTower.GetComponent<BuildTower>().tower = newTower;
			GetComponent<TowerShooting>().enabled = true;
			Destroy(this);
		}
	}
}
