using UnityEngine;
using System.Collections;

public class EnemyController : Ship {

	// Use this for initialization
	void Start () {
		init (1, 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		switch (other.tag) {
		case "Player":
			Died();
			PlayerController shipScript = other.GetComponent<PlayerController> ();
			shipScript.IsHitted (shipScript.GetLife());
			break;
		default:
			break;
		}
	}
}
