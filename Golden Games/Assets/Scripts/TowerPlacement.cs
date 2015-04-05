using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {

	public int price;

	// Use this for initialization
	void Start () {
		PlaceAtMousePosition ();
	}

	private RaycastHit hit;  

	void Update () {
		PlaceAtMousePosition ();
		if (Input.GetMouseButtonDown (0)) {
			GetComponent<TowerShooting>().enabled = true;
			Resources.ChangeGoldAmount(-price);
			Destroy(this);
		}
	}

	void PlaceAtMousePosition ()
	{
		int groundLayermask = 1 << LayerMask.NameToLayer ("Ground");
		Ray ray = MainCamera.Get ().GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, groundLayermask)) {
			//&& Input.GetMouseButtonDown (0) && hit.transform.name == "Play"
			transform.position = hit.point;
		}
	}
}
