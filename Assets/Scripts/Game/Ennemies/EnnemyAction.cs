using UnityEngine;
using System.Collections;

public class EnnemyAction : MonoBehaviour {
	
	private float fireRate;
	private float nextFire;

	public int fireType;
	
	private Arsenal arsenal;

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		arsenal = gameControllerObject.GetComponent<Arsenal>();

		fireRate = arsenal.GetFireRate (fireType);
	}

	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			
			arsenal.Fire (transform, fireType, gameObject.tag);
		}
	}
}
