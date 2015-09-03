using UnityEngine;
using System.Collections;

public class ArsenalUp : Items {
	
	protected override void ItemEffect (GameObject player) {
		PlayerAction playerAction = player.GetComponent<PlayerAction> ();
		playerAction.fireLevel = playerAction.fireLevel + effectMultiplicator;
	}
}
