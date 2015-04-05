using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	private RaycastHit hit;  

	void Update () {
		int groundLayermask = 1 << LayerMask.NameToLayer ("Ground");

		Ray ray = MainCamera.Get().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, groundLayermask)) { //&& Input.GetMouseButtonDown (0) && hit.transform.name == "Play"
			transform.position = hit.point;
		}

		if (Input.GetMouseButtonDown (0)) {
			GetComponent<TowerShooting>().enabled = true;
			Destroy(this);
		}
	}
}
