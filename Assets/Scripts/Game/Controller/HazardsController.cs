using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HazardsController : MonoBehaviour {
	
	public GameObject[] asteroidsOrdered;
	public Vector3 spawnValuesMin;
	public Vector3 spawnValuesMax;
	public Vector3 spawnValuesLimit;

	private float startWait = 5f;

	List<Manoeuvre> manoeuvres;
	SetupDifficulty setupDiff;

	private GameController gameController;

	void Start () {
		gameController = GetComponent<GameController>();

		List<string> patternsString = LoadResources.loadTxtAsListString ();
		manoeuvres = new List<Manoeuvre> ();
		int i = 0;

		for (; i < patternsString.Count; ++i) {
			manoeuvres.Add (Manoeuvre.Create(patternsString[i]));
		}
	}

	public void SetHazards (SetupDifficulty setDiff) {
		setupDiff = setDiff;
	}

	public void StartHazards () {
		int i = setupDiff.simultaneousPattern;
		for (; i > 0; --i) {
			StartCoroutine(SpawnWaves());
		}
	}

	IEnumerator SpawnWaves () {
		int i = 0, len = 0;

		Manoeuvre currManoeuvre;
		Formation currFormation;

		Quaternion spawnRotation = Quaternion.identity;
		GameObject hazardObject;
		SpecialMover specialMover;

		yield return new WaitForSeconds(startWait);
		while (true) {
			currManoeuvre = manoeuvres[Random.Range (0, manoeuvres.Count)];
			currManoeuvre.StartManoeuvre ();


			while( (currFormation = currManoeuvre.GetNextFormation()) != null) {
				if (gameController.gameState == Constants.GAMEOVER) {
					break;
				}

				i = 0;
				len = currFormation.formation.Length;

				for (; i < len; ++i) {
					hazardObject = (GameObject) Instantiate(asteroidsOrdered[setupDiff.indexAsteroids], currFormation.formation[i].posStart, spawnRotation);
					specialMover = hazardObject.GetComponent<SpecialMover> ();
					specialMover.SetPattern (currFormation.formation[i]);
				}

				yield return new WaitForSeconds(currFormation.timer * setupDiff.coefWaitFormation);
			}
			
			if (gameController.gameState == Constants.GAMEOVER) {
				break;
			} else {
				yield return new WaitForSeconds(setupDiff.waitBtwWave);
			}
		}
		if (gameController.gameState == Constants.GAMEOVER) {
			yield break;
		}
	}
}
