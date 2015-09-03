using UnityEngine;
using System.Collections;

public class LifeUp : Items {
	
	protected override void ItemEffect (GameObject player) {
		PlayerController playerController = player.GetComponent<PlayerController>();
		playerController.SetLife(playerController.GetLife() + effectMultiplicator);
	}
}
