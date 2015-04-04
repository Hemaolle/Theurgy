using UnityEngine;
using System.Collections;

public class MaintainRotation : MonoBehaviour {

	public GameObject HpBar;
	public GameObject HpBarLocation;

	Quaternion rotation;
	
	void Awake()
	{
		rotation = HpBar.transform.rotation;
	}
	
	void LateUpdate()
	{        
		var position = MainCamera.Get().GetComponent<Camera>().WorldToNormalizedViewportPoint(HpBarLocation.transform.position);
		HpBar.transform.position = OrtographicCamera.Get().GetComponent<Camera>().NormalizedViewportToWorldPoint(position);
		HpBar.transform.rotation = rotation;
	}

}
