using UnityEngine;
using System.Collections;

public class DestroyInTime : MonoBehaviour {

	public float time = 2f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, time);
	}

}
