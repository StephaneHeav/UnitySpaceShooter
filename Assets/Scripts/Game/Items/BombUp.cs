using UnityEngine;
using System.Collections;

public class BombUp : Items {
	
	protected override void ItemEffect (GameObject player) {
		PlayerController playerController = player.GetComponent<PlayerController>();
		playerController.SetBomb(playerController.GetBomb() + effectMultiplicator);
	}
}
