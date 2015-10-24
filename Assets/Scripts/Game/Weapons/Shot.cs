﻿using UnityEngine;
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
				if (owner == "Enemies") {
					Hit ();
					PlayerController shipScript = other.GetComponent<PlayerController> ();
					shipScript.IsHitted (Damage);
				}
				break;
			case "Lore":
				if (owner == "Player") {
					Hit ();
					Lore loreScript = other.GetComponent<Lore> ();
					if (loreScript.IsHitted (Damage) == Constants.DEAD) {
						uiController.AddScore(Constants.INDEXSCORETLORES, Constants.INDEXSCORESSHOT, false, 0);
						itemController.spawnItem (other.transform);
					}
				}
				break;
			case "Enemies":
				if (owner == "Player") {
					Hit ();
					EnemyController shipScript = other.GetComponent<EnemyController> ();
					if (shipScript.IsHitted (Damage) == Constants.DEAD) {
						uiController.AddScore(shipScript.indexScoreEnemy, Constants.INDEXSCORESSHOT, false, 0);
						itemController.spawnItem (other.transform);
					}
				}
				break;
			default:
				break;
			}
		}
	}

	public void IsDestroyed () {
		Destroy(gameObject);
	}

	private void Hit () {
		Instantiate(explosion, transform.position, transform.rotation);
		IsDestroyed ();
	}
}
