using UnityEngine;
using System.Collections;

public class ScoreUp : Items {

	protected override void ItemEffect (GameObject player) {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		UIController uiController = gameControllerObject.GetComponent<UIController>();
		uiController.AddScore(0, 0, false, effectMultiplicator);
	}
}