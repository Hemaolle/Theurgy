using UnityEngine;
using System.Collections;

public class OrtographicCamera : MonoBehaviour {

	static GameObject instance;
	
	void Awake() {
		instance = gameObject;
	}
	
	public static GameObject Get() {
		return instance;
	}
}
