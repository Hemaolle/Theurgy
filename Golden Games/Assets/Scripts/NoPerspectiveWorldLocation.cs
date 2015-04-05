using UnityEngine;
using System.Collections;

public class NoPerspectiveWorldLocation : MonoBehaviour {

	public GameObject UIElement;
	public GameObject WorldLocation;

	Quaternion rotation;
	
	void Awake()
	{
		rotation = UIElement.transform.rotation;
	}
	
	void LateUpdate()
	{        
		var position = MainCamera.Get().GetComponent<Camera>().WorldToNormalizedViewportPoint(WorldLocation.transform.position);
		UIElement.transform.position = OrtographicCamera.Get().GetComponent<Camera>().NormalizedViewportToWorldPoint(position);
		UIElement.transform.rotation = rotation;
	}

}
