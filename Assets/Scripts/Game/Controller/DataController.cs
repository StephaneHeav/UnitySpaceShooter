using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataController : MonoBehaviour {
	public List<InputManager> inputManager = new List<InputManager>();
	private int playerShip = 0;
	private int currentDifficulty = Constants.DIFFICULTYMASTER;
	private ScoreObject[] scores = new ScoreObject[] {
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0),
		new ScoreObject ("", 0)
	};

	void Awake () {
		DontDestroyOnLoad (this);
		ResetData ();
		LoadData ();
	}


	/**
	 * Keys Binding Data Method
	 */
	public void SetInputManager (int index, InputManager im) {
		inputManager[index].keyName = im.keyName;
		inputManager[index].key = im.key;
		PlayerPrefs.SetString(inputManager[index].keyName, inputManager[index].key);
	}
	public List<InputManager> GetInputManager () {
		return inputManager;
	}
	public KeyCode GetKeyInput (string name) {
		return  (KeyCode) System.Enum.Parse(typeof(KeyCode), (inputManager.Find (str => string.Equals(str.keyName, name))).key );
	}


	/**
	 * Player Ship Data Method
	 */
	public void SetPlayerShip (int selectedShip) {
		playerShip = selectedShip;
		PlayerPrefs.SetInt (Constants.KEYDATAPLAYER, playerShip);
	}
	public int GetPlayerShip () {
		return playerShip;
	}


	/**
	 * Difficulty Data Method
	 */
	public void SetDifficulty (int selectedDifficulty) {
		currentDifficulty = selectedDifficulty;
		PlayerPrefs.SetInt (Constants.KEYDATADIFFICULTY, currentDifficulty);
	}
	public int GetDifficulty () {
		return currentDifficulty;
	}


	/**
	 * Scores Data Method
	 */
	public void SetScores (string name, int newScore) {
		int i = 0, len = scores.Length, tmpScore;
		string tmpName;

		for (; i < len; ++i) {
			if (newScore >= scores[i].score) {
				tmpScore = scores[i].score;
				tmpName = scores[i].playerName;

				scores[i].score = newScore;
				scores[i].playerName = name;

				newScore = tmpScore;
				name = tmpName;

				
				PlayerPrefs.SetInt (Constants.KEYDATASCOREV+i, scores[i].score);
				PlayerPrefs.SetString (Constants.KEYDATASCOREN+i, scores[i].playerName);
			}
		}
	}
	public ScoreObject[] GetScores () {
		return scores;
	}
	

	/**
	 * General Data Method
	 */
	private void SaveData () {
		PlayerPrefs.SetInt (Constants.KEYDATAPLAYER, playerShip);
		PlayerPrefs.SetInt (Constants.KEYDATADIFFICULTY, currentDifficulty);

		int i = scores.Length - 1;
		for (; i >= 0; --i) {
			PlayerPrefs.SetInt (Constants.KEYDATASCOREV+i, scores[i].score);
			PlayerPrefs.SetString (Constants.KEYDATASCOREN+i, scores[i].playerName);
		}
	}

	private void LoadData () {
		if (PlayerPrefs.HasKey (Constants.KEYDATAPLAYER)) {
			playerShip = PlayerPrefs.GetInt (Constants.KEYDATAPLAYER);
		}
		if (PlayerPrefs.HasKey (Constants.KEYDATADIFFICULTY)) {
			currentDifficulty = PlayerPrefs.GetInt (Constants.KEYDATADIFFICULTY);
		}

		int i = scores.Length - 1;
		for (; i >= 0; --i) {
			if (PlayerPrefs.HasKey (Constants.KEYDATASCOREV+i) && PlayerPrefs.HasKey (Constants.KEYDATASCOREN+i)) {
				scores[i].score = PlayerPrefs.GetInt (Constants.KEYDATASCOREV+i);
				scores[i].playerName = PlayerPrefs.GetString (Constants.KEYDATASCOREN+i);
			}
		}

		i = inputManager.Count - 1;
		for (; i >= 0; --i) {
			if (PlayerPrefs.HasKey (inputManager[i].keyName)) {
				inputManager[i].key = PlayerPrefs.GetString (inputManager[i].keyName);
			}
		}
	}

	private void ResetData () {
		PlayerPrefs.DeleteAll ();
	}
}
