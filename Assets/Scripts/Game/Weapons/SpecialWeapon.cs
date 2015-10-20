using UnityEngine;
using System.Collections;

public class SpecialWeapon : MonoBehaviour {
	public float speed = 0.5f;
	public float limit = 3f;
	public float growZ = 0f;

	private float lifetime = 0f;

	public void FillUp () {
		lifetime = 1f;
	}

	private void Empty () {
		Destroy(gameObject);
	}

	void FixedUpdate () {
		lifetime = lifetime - Time.deltaTime;
		if (lifetime > 0 && transform.localScale.x < limit) {
			transform.localScale += new Vector3 (speed, 0, speed*growZ);
		} else if (lifetime < 0 && transform.localScale.x > 0) {
			transform.localScale -= new Vector3 (speed, 0, speed*growZ);
		}

		if ( transform.localScale.x <= 0) {
			Empty ();
		}
	}

	void OnTriggerEnter (Collider other) {
		CollisionManager (other);
	}
	void OnTriggerStay (Collider other) {
		CollisionManager (other);
	}

	private void CollisionManager (Collider other) {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		UIController uiController = gameControllerObject.GetComponent<UIController>();
		
		switch (other.tag) {
		case "Player":
			break;
		case "Lore":
			Lore loreScript = other.GetComponent<Lore>();
			if (loreScript.IsHitted(loreScript.GetHealth()) == Constants.DEAD) {
				uiController.AddScore(Constants.INDEXSCORETLORES, Constants.INDEXSCORESSW, false, 0);
			}
			break;
		case "Enemies":
			Ship shipScript = other.GetComponent<Ship>();
			if (shipScript.IsHitted(shipScript.GetHealth()) == Constants.DEAD) {
				uiController.AddScore(Constants.INDEXSCORETENEMIES, Constants.INDEXSCORESSW, false, 0);
			}
			break;
		case "Shot":
			Shot shotScript = other.GetComponent<Shot>();

			if (shotScript.GetOwner() != "Player") {
				shotScript.IsDestroyed ();			
				uiController.AddScore(Constants.INDEXSCORETSHOT, Constants.INDEXSCORESSW, false, 0);
			}
			break;
		default:
			break;
		}
	}
}
