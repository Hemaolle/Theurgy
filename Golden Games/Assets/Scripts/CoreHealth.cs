using UnityEngine;
using System.Collections;

public class CoreHealth : EnemyHealth {

	public GameObject gameOverScreen;

	protected override void Death ()
	{
		Time.timeScale = 0;
		gameOverScreen.SetActive (true);
	}
}
