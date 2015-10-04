using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HazardsController : MonoBehaviour {
	
	public GameObject[] asteroidsOrdered;
	public GameObject foe;
	public Vector3 spawnValuesMin;
	public Vector3 spawnValuesMax;
	public Vector3 spawnValuesLimit;

	private float startWait = 5f;
	
	List<Manoeuvre> manoeuvresLore;
	List<Manoeuvre> manoeuvresFoe;
	SetupDifficulty setupDiff;

	private GameController gameController;

	void Start () {
		int i;
		List<string> patternsString;

		gameController = GetComponent<GameController>();
		
		patternsString = LoadResources.loadTxtAsListString ("PatternLore");
		manoeuvresLore = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresLore.Add (Manoeuvre.Create(patternsString[i]));
		}
		
		patternsString = LoadResources.loadTxtAsListString ("PatternFoe");
		manoeuvresFoe = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresFoe.Add (Manoeuvre.Create(patternsString[i]));
		}
	}

	public void SetHazards (SetupDifficulty setDiff) {
		setupDiff = setDiff;
	}

	public void StartHazards () {
		int i = setupDiff.simultaneousPattern;
		for (; i > 0; --i) {
			StartCoroutine(SpawnWavesLore());
		}
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWavesLore () {
		int i = 0, len = 0;

		Manoeuvre currManoeuvre;
		Formation currFormation;

		Quaternion spawnRotation = Quaternion.identity;
		GameObject hazardObject;
		SpecialMover specialMover;

		yield return new WaitForSeconds(startWait);
		while (true) {
			currManoeuvre = manoeuvresLore[Random.Range (0, manoeuvresLore.Count)];
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
					specialMover.SetPattern (currFormation.formation[i].GetClone());
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
	
	IEnumerator SpawnWaves () {
		int i = 0, len = 0;
		
		Manoeuvre currManoeuvre;
		Formation currFormation;
		
		Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
		GameObject hazardObject;
		SpecialMover specialMover;
		
		yield return new WaitForSeconds(startWait);
		while (true) {
			currManoeuvre = manoeuvresFoe[Random.Range (0, manoeuvresFoe.Count)];
			currManoeuvre.StartManoeuvre ();
			
			
			while( (currFormation = currManoeuvre.GetNextFormation()) != null) {
				if (gameController.gameState == Constants.GAMEOVER) {
					break;
				}
				
				i = 0;
				len = currFormation.formation.Length;
				
				for (; i < len; ++i) {
					hazardObject = (GameObject) Instantiate(foe, currFormation.formation[i].posStart, spawnRotation);
					specialMover = hazardObject.GetComponent<SpecialMover> ();
					specialMover.SetPattern (currFormation.formation[i].GetClone());
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
