using UnityEngine;
using System.Collections;

public abstract class Ship : MonoBehaviour {
	
	public GameObject explosion;

	protected int life;
	protected int health;
	protected int maxHealth;
	protected int state = Constants.IMMORTAL;

	public void init (int newLife, int newMaxHealth) {
		life = newLife;
		maxHealth = newMaxHealth;
		health = maxHealth;
	}

	public int GetLife () {
		return life;
	}
	public void SetLife (int newLife) {
		life = newLife;
	}
	public int GetHealth () {
		return health;
	}
	public int GetMaxHealth () {
		return maxHealth;
	}
	public void SetMaxHealth (int newMaxHealth) {
		maxHealth = newMaxHealth;
		health = maxHealth;
	}
	public int GetState () {
		return state;
	}
	public void ActivateState () {
		state = Constants.ALIVE;
	}
	
	public int IsHitted (int damage) {
		if (state != Constants.IMMORTAL && state == Constants.ALIVE) {
			health = health - damage;
			if (health <= 0) {
				Died();
			}
		}

		return state;
	}
	
	protected void Died () {
		Instantiate (explosion, transform.position, transform.rotation);

		if ((--life) <= 0) {
			Destroy(gameObject);
			state = Constants.DEAD;
			health = 0;
		} else {
			Respawn();
		}
	}

	protected void Respawn () {
		health = maxHealth;
	}
}