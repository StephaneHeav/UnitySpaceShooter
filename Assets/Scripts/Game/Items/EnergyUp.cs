using UnityEngine;
using System.Collections;

public class EnergyUp : Items {
	
	protected override void ItemEffect (GameObject player) {
		PlayerController playerController = player.GetComponent<PlayerController>();
		playerController.SetEnergy(playerController.GetEnergy() + (float)effectMultiplicator);
	}
}
