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
		
		patternsString = LoadResources.LoadTxtAsListString ("PatternLore");
		manoeuvresLore = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresLore.Add (Manoeuvre.Create(patternsString[i]));
		}
		
		patternsString = LoadResources.LoadTxtAsListString ("PatternFoe");
		manoeuvresFoe = new List<Manoeuvre> ();
		
		for (i = 0; i < patternsString.Count; ++i) {
			manoeuvresFoe.Add (Manoeuvre.Create(patternsString[i]));
		}
	}

	public void SetHazards (SetupDifficulty setDiff) {
		setupDiff = setDiff;
	}

	public void StartHazards () {
		StartCoroutine(SpawnWavesRandom(Quaternion.identity, asteroidsOrdered[setupDiff.indexAsteroids], manoeuvresLore));
		StartCoroutine(SpawnWavesRandom(Quaternion.Euler(0, 180, 0), foe, manoeuvresFoe));
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

			while( (currFormation = currManoeuvre.GetNextFormation()) != null || gameController.gameState == Constants.GAMEOVER) {
				i = 0;
				len = currFormation.formation.Length;

				for (; i < len; ++i) {
					hazardObject = (GameObject) Instantiate(gameObj, currFormation.formation[i].posStart, spawnRotation);
					specialMover = hazardObject.GetComponent<SpecialMover> ();
					specialMover.SetPattern (currFormation.formation[i].GetClone());
				}

				yield return new WaitForSeconds(currFormation.timer * setupDiff.coefWaitFormation);
			}
				
			yield return new WaitForSeconds(setupDiff.waitBtwWave);
		}

		yield break;
	}
}
