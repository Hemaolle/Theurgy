using UnityEngine;
using System.Collections;

public class FloatAndDestroy : MonoBehaviour {

	public float speed;
	public float distance;

	// Use this for initialization
	void Start () {
		Vector3 target = transform.position + Vector3.up * distance;
		iTween.MoveTo (gameObject, iTween.Hash ("x", target.x,
		                                        "y", target.y,
		                                        "z", target.z,
		                                        "speed", speed,
		                                        "easetype", iTween.EaseType.linear,
		                                        "oncomplete", "DestroyGameObject"));
	}

	void DestroyGameObject() {
		Destroy (gameObject);
	}
}
