using UnityEngine;
using System.Collections;

public abstract class Items : MonoBehaviour {

	public int effectMultiplicator;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Destroy(gameObject);
			ItemEffect(other.gameObject);
		}
	}

	protected abstract void ItemEffect (GameObject player);
}