using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resources : MonoBehaviour {

	public int startingGold;
	public Text goldText;

	void Start() {
		currentGold = startingGold;
		staticGoldText = goldText;
		staticGoldText.text = "Gold: " + currentGold;
	}

	static int currentGold;
	static Text staticGoldText;

	public static bool ChangeGoldAmount(int change) {
		if (currentGold + change < 0) {
			return false;
		} else {
			currentGold += change;
			staticGoldText.text = "Gold: " + currentGold;
			return true;
		}
	}

	public static bool CanAfford(int price) {
		if (currentGold < price) {
			return false;
		} else {
			return true;
		}
	}
}
