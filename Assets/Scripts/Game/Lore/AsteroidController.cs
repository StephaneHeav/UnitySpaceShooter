using UnityEngine;
using System.Collections;

public class AsteroidController : Lore {

	void Start () {
		init(15);
	}

	void OnTriggerEnter (Collider other) {
		switch (other.tag) {
		case "Player":
			Died();
			break;
		default:
			break;
		}
	}
}