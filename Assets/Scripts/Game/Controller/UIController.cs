using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {
	public Text scoreText;
	public Text lifeText;
	public Text bombText;
	public Slider energySlider;

	private float multiplicator;
	
	private int score;
	private int[] scoreTable = new int[] {10,1,1};
	private int[] multiplicatorTable = new int[] {100,10,10};

	void Start () {
		energySlider.maxValue = Constants.ENERGYMAX;
		energySlider.value = Constants.ENERGYMAX;
		multiplicator = 1;
		score = 0;
		UpdateScore();
	}

	public void UpdateEnergy (float newEnergy) {
		energySlider.value = newEnergy;
	}

	public void AddScore (int target, int source, bool hasMultiplicator, int forceScore) {
		int newScoreValue = 0;

		if (forceScore == 0) {
			newScoreValue = scoreTable[target] * multiplicatorTable[source];
		} else {
			newScoreValue = forceScore;
		}

		if (hasMultiplicator) {
			if (newScoreValue > 0) {
				multiplicator += 0.01f;
			} else {
				multiplicator = 1f;
			}
			score += (int)Mathf.Floor (newScoreValue * multiplicator);
		} else {
			score += newScoreValue;
		}

		if (score < 0) {
			score = 0;
		}
		UpdateScore();
	}

	public int GetScore () {
		return score;
	}
	
	private void UpdateScore () {
		scoreText.text = "Score: " + score;
	}
	
	public void UpdatePlayerInfo (int life, int bomb) {
		lifeText.text = "Life x" + life;
		bombText.text = "Bombs x" + bomb;
	}
}
