using UnityEngine;
using System;
using System.Collections;

public class EnemyAction : MonoBehaviour {
	public int typeIAAction = 0;

	private float fireRate;
	private float nextFire;

	public int fireType;
	
	private Arsenal arsenal;
	private GameObject playerObj;
	private Action actionFunc;

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		arsenal = gameControllerObject.GetComponent<Arsenal>();

		playerObj = GameObject.FindGameObjectWithTag("Player");

		fireRate = arsenal.GetFireRate (fireType);
		switch (typeIAAction) {
		case 1:
			actionFunc = complexeAction;
			break;
		default:
			actionFunc = simpleAction;
			break;
		}
	}

	void Update () {
		actionFunc ();
	}

	private void simpleAction () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			
			arsenal.Fire (transform, fireType, gameObject.tag);
		}
	}

	private void complexeAction () {
		if (Time.time > nextFire && playerObj.transform.position.x >= transform.position.x - 2 && playerObj.transform.position.x <= transform.position.x + 2) {
			nextFire = Time.time + fireRate;
			
			arsenal.Fire (transform, fireType, gameObject.tag);
		}
	}
}
