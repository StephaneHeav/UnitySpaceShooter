﻿using UnityEngine;
using System.Collections;

public class ActiveByBoundary : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		switch (other.tag) {
		case "Player":
		case "Ennemies":
			Ship shipScript = other.GetComponent<Ship> ();
			shipScript.ActivateState ();
			break;
		case "Lore":
			Lore loreScript = other.GetComponent<Lore>();
			loreScript.ActivateState ();
			break;
		default:
			break;
		}
	}
}
