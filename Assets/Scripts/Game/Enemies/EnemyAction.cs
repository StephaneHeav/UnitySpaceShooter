using UnityEngine;
using System;
using System.Collections;

public class EnemyAction : MonoBehaviour {
	public int typeIAAction = 0;

	private float fireRate;
	private float nextFire;

	public int fireType;
	
	private Arsenal arsenal;
	private Action actionFunc;
	private GameObject playerShip;

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		arsenal = gameControllerObject.GetComponent<Arsenal>();

		playerShip = GameObject.FindGameObjectWithTag ("Player");

		fireRate = arsenal.GetFireRate (fireType);

		switch (typeIAAction) {
		case 1:
			//nothing
			break;
		default:
			StartCoroutine(simpleAction());
			break;
		}
	}

	public void SetComplexeAction (int typeCA) {
		StartCoroutine(complexeAction(0f, typeCA));
	}

	IEnumerator simpleAction () {
		while (true) {
			arsenal.Fire (transform, fireType, gameObject.tag);

			yield return new WaitForSeconds (fireRate);
		}
	}

	IEnumerator complexeAction (float delay, int typeCA) {
		Manoeuvre lastManoeuvre;
		Formation currFormation;
		int i, len;

		yield return new WaitForSeconds(delay);
		while (true) {
			switch (typeCA) {
			case 1:
				lastManoeuvre = PatternFactory.SpiralPattern (16, 1, 0.1f, transform.position);
				break;
			case 2:
				lastManoeuvre = PatternFactory.CirclePattern (16, 1, 0.1f, transform.position);
				break;
			case 3:
				lastManoeuvre = PatternFactory.HalfCirclePattern (16, 1, 1f, transform.position, playerShip.transform.position);
				break;
			default:
				lastManoeuvre = PatternFactory.QuarterCirclePattern (16, 1, 1f, transform.position, playerShip.transform.position);
				break;
			}
			lastManoeuvre.StartManoeuvre ();
			
			while( (currFormation = lastManoeuvre.GetNextFormation()) != null && currFormation.formation != null) {
				i = 0;
				len = currFormation.formation.Length;
				
				for (; i < len; ++i) {
					GameObject shot = arsenal.Fire (transform, fireType, gameObject.tag);
					SpecialMover spScrip = shot.GetComponent<SpecialMover> ();
					spScrip.SetTrajectory (currFormation.formation[i].GetClone());
				}
				
				yield return new WaitForSeconds(currFormation.timer);
			}
			
			yield return new WaitForSeconds (1f);
		}
	}
}
