using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingText : MonoBehaviour {

	public float speed;
	public float distance;
	public GameObject floatThis;
	public Text uiText;
	public string text;

	// Use this for initialization
	void Start () {
		uiText.text = text;
		Vector3 target = floatThis.transform.position + Vector3.up * distance;
		iTween.MoveTo (floatThis, iTween.Hash ("x", target.x,
		                                        "y", target.y,
		                                        "z", target.z,
		                                        "speed", speed,
		                                        "easetype", iTween.EaseType.linear,
		                                        "oncompletetarget", gameObject,
		                                        "oncomplete", "DestroyGameObject"));
	}

	void DestroyGameObject() {
		Destroy (gameObject);
	}
}
