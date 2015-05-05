using UnityEngine;
using System.Collections;

public class ReloadGame : MonoBehaviour {

	public void Reload() {
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}
}
