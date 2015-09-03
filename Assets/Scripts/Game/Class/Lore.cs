using UnityEngine;
using System.Collections;

public abstract class Lore : MonoBehaviour {
	public GameObject explosion;

	private int health;
	private int state = Constants.IMMORTAL;
	
	public int GetState () {
		return state;
	}
	public void ActivateState () {
		state = Constants.ALIVE;
	}
	public void init (int newHealth) {
		health = newHealth;
	}
	public int GetHealth () {
		return health;
	}

	
	public int IsHitted (int damage) {
		if (state != Constants.IMMORTAL) {
			health = health - damage;
			if (health <= 0) {
				if (state == Constants.ALIVE) {
					Died ();
				}
			}
		}
		
		return state;
	}
	
	protected void Died () {
		state = Constants.DEAD;

		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
