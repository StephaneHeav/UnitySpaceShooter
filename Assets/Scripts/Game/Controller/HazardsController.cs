using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HazardsController : MonoBehaviour {
	
	public GameObject[] asteroidsOrdered;
	public GameObject[] enemies;
	public Vector3 spawnValuesMin;
	public Vector3 spawnValuesMax;
	public Vector3 spawnValuesLimit;

	private float startWait = 5f;
	
	List<Manoeuvre> manoeuvresLore;
	List<Manoeuvre> manoeuvresEnemie;
	List<Manoeuvre> manoeuvresSpecialForce;
	SetupDifficulty setupDiff;

	private GameController gameController;

	void Start () {
		int i;
		List<string> patternsString;

		gameController = GetComponent<GameController>();
		
		patternsString = LoadResources.LoadTxtAsListString ("PatternLore");
		manoeuvresLore = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresLore.Add (Manoeuvre.Create(patternsString[i]));
		}
		
		patternsString = LoadResources.LoadTxtAsListString ("PatternFoe");
		manoeuvresEnemie = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresEnemie.Add (Manoeuvre.Create(patternsString[i]));
		}
		
		patternsString = LoadResources.LoadTxtAsListString ("PatternSpecialForce");
		manoeuvresSpecialForce = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresSpecialForce.Add (Manoeuvre.Create(patternsString[i]));
		}
	}

	public void SetHazards (SetupDifficulty setDiff) {
		setupDiff = setDiff;
	}

	public void StartHazards () {
		//StartCoroutine(SpawnWavesRandom(Quaternion.identity, asteroidsOrdered[setupDiff.indexAsteroids], manoeuvresLore));
		//StartCoroutine(SpawnWavesRandom(Quaternion.Euler(0, 180, 0), enemies[0], manoeuvresEnemie));
		//StartCoroutine(SpawnSpecialForce());
	}
	
	IEnumerator SpawnWavesRandom (Quaternion spawnRotation, GameObject gameObj, List<Manoeuvre> manoeuvresList) {
		int i = 0, len = 0;
		
		Manoeuvre currManoeuvre;
		Formation currFormation;
		
		GameObject hazardObject;
		SpecialMover specialMover;
		
		yield return new WaitForSeconds(startWait);
		
		while (gameController.gameState != Constants.GAMEOVER) {
			currManoeuvre = manoeuvresList[Random.Range (0, manoeuvresList.Count)];
			currManoeuvre.StartManoeuvre ();
			
			while( (currFormation = currManoeuvre.GetNextFormation()) != null && currFormation.formation != null && gameController.gameState != Constants.GAMEOVER) {
				for (i = 0, len = currFormation.formation.Length; i < len; ++i) {
					hazardObject = (GameObject) Instantiate(gameObj, currFormation.formation[i].posStart, spawnRotation);
					specialMover = hazardObject.GetComponent<SpecialMover> ();
					specialMover.SetTrajectory (currFormation.formation[i].GetClone());
				}
				
				yield return new WaitForSeconds(currFormation.timer * setupDiff.coefWaitFormation);
			}
			
			yield return new WaitForSeconds(setupDiff.waitBtwWave + 10f);
		}
		
		yield break;
	}
	
	IEnumerator SpawnSpecialForce () {
		int i = 0, len = 0, selectedTCA;
		
		Manoeuvre currManoeuvre;
		Formation currFormation;
		GameObject hazardObject;
		SpecialMover specialMover;
		EnemyAction enemyAction;
		
		yield return new WaitForSeconds(startWait);

		while (gameController.gameState != Constants.GAMEOVER) {
			
			yield return new WaitForSeconds(30f);

			currManoeuvre = manoeuvresSpecialForce[Random.Range (0, manoeuvresSpecialForce.Count)];
			currManoeuvre.StartManoeuvre ();
			
			while( (currFormation = currManoeuvre.GetNextFormation()) != null && currFormation.formation != null && gameController.gameState != Constants.GAMEOVER) {
				selectedTCA = Random.Range (0, 3);
				for (i = 0, len = currFormation.formation.Length; i < len; ++i) {
					hazardObject = (GameObject) Instantiate(enemies[1], currFormation.formation[i].posStart, Quaternion.Euler(0, 180, 0));
					specialMover = hazardObject.GetComponent<SpecialMover> ();
					specialMover.SetTrajectory (currFormation.formation[i].GetClone());
					enemyAction = hazardObject.GetComponent<EnemyAction> ();
					enemyAction.SetComplexeAction(selectedTCA);
				}

				yield return new WaitForSeconds(currFormation.timer * setupDiff.coefWaitFormation);
			}
		}
		
		yield break;
	}
}
