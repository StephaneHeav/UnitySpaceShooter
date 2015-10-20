using UnityEngine;
using System.Collections;

public class Bomb : Weapon {

	void OnTriggerEnter (Collider other) {
		hasCollide (other);
	}
	void OnTriggerStay (Collider other) {
		hasCollide (other);
	}

	private void hasCollide (Collider other) {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		ItemsController itemController = gameControllerObject.GetComponent<ItemsController>();
		UIController uiController = gameControllerObject.GetComponent<UIController>();
		
		switch (other.tag) {
		case "Player":
			break;
		case "Lore":
			Lore loreScript = other.GetComponent<Lore>();
			if (loreScript.IsHitted(loreScript.GetHealth()) == Constants.DEAD) {
				uiController.AddScore(Constants.INDEXSCORETLORES, Constants.INDEXSCORESBOMB, false, 0);
				itemController.spawnItem(other.transform);
			}
			break;
		case "Ennemies":
			Ship shipScript = other.GetComponent<Ship>();
			if (shipScript.IsHitted(shipScript.GetHealth()) == Constants.DEAD) {
				uiController.AddScore(Constants.INDEXSCORETENNEMIES, Constants.INDEXSCORESBOMB, false, 0);
				itemController.spawnItem(other.transform);
			}
			break;
		case "Shot":
			Shot shotScript = other.GetComponent<Shot>();

			if (shotScript.GetOwner() != "Player") {
				shotScript.IsDestroyed ();
				uiController.AddScore(Constants.INDEXSCORETSHOT, Constants.INDEXSCORESBOMB, false, 0);
			}
			break;
		default:
			break;
		}
	}
}
