using UnityEngine;
using System.Collections;

public class Shot : Weapon {
	public GameObject explosion;

	void OnTriggerEnter (Collider other) {
		if (transform.position.z <= 15 && transform.position.x < 7.5 && transform.position.x > -7.5) {
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			ItemsController itemController = gameControllerObject.GetComponent<ItemsController> ();
			UIController uiController = gameControllerObject.GetComponent<UIController> ();

			switch (other.tag) {
			case "Player":
				if (owner == "Ennemies") {
					hit ();
					PlayerController shipScript = other.GetComponent<PlayerController> ();
					shipScript.IsHitted (Damage);
				}
				break;
			case "Lore":
				if (owner == "Player") {
					hit ();
					Lore loreScript = other.GetComponent<Lore> ();
					if (loreScript.IsHitted (Damage) == Constants.DEAD) {
						uiController.AddScore(Constants.INDEXSCORETLORES, Constants.INDEXSCORESSHOT, false, 0);
						itemController.spawnItem (other.transform);
					}
				}
				break;
			case "Ennemies":
				if (owner == "Player") {
					hit ();
					EnnemyController shipScript = other.GetComponent<EnnemyController> ();
					if (shipScript.IsHitted (Damage) == Constants.DEAD) {
						uiController.AddScore(Constants.INDEXSCORETENNEMIES, Constants.INDEXSCORESSHOT, false, 0);
						itemController.spawnItem (other.transform);
					}
				}
				break;
			default:
				break;
			}
		}
	}

	private void hit () {
		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
