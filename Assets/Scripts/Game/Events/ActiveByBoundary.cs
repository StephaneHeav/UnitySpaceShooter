using UnityEngine;
using System.Collections;

public class ActiveByBoundary : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		switch (other.tag) {
		case "Player":
			break;
		case "Enemies":
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
