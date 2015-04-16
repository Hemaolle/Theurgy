﻿using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {

	public int price;

	bool placementPossible;
	bool collidingWithATower;

	// Use this for initialization
	void Start () {
		if (!PlaceAtMousePosition ("Ground")) {
			PlaceAtMousePosition("GroundNoPlacement");
		}
	}

	private RaycastHit hit;  

	void Update () {
		if (PlaceAtMousePosition ("Ground") && !collidingWithATower) {
			SetPlacementPossible (true);
		} else {
			PlaceAtMousePosition("GroundNoPlacement");
			SetPlacementPossible (false);
		}

		if (placementPossible && Input.GetMouseButtonDown (0)) {
			GetComponent<TowerShooting>().enabled = true;
			Resources.ChangeGoldAmount(-price);
			Destroy(this);
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Tower") {
			collidingWithATower = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.tag == "Tower") {
			collidingWithATower = false;
		}
	}

	void SetPlacementPossible (bool possible)
	{
		foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer> ())
			meshRenderer.material.color = possible ? Color.white : Color.red;
		placementPossible = possible;
	}

	bool PlaceAtMousePosition (string layerName)
	{
		Debug.Log("Placement raycast: " + layerName);
		int groundLayermask = 1 << LayerMask.NameToLayer (layerName);
		Ray ray = MainCamera.Get ().GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, groundLayermask)) {
			//&& Input.GetMouseButtonDown (0) && hit.transform.name == "Play"

			transform.position = hit.point;
			return true;
		}
		return false;
	}
}
