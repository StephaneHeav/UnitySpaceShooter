using UnityEngine;
using System.Collections;

public class ItemsController : MonoBehaviour {
	
	public GameObject[] items;
	public int[] weights;
	public int maxWeight;
	public int dropRate;
	public GameObject itemScore;
		
	public void spawnItem (Transform spawn) {
		int randomValue = Random.Range (0, (100/dropRate));
		if (randomValue == 1) {
			loterieItem (spawn);
		} else if (randomValue <= (50/dropRate)) {
			spawnScoreItem (spawn);
		}
	}

	public void spawnScoreItem (Transform spawn) {
		Instantiate(itemScore, spawn.position, Quaternion.Euler (0.0f, 0.0f, 0.0f));
	}

	private void loterieItem (Transform spawn) {
		int randomValue = Random.Range (0, maxWeight);
		int i = 0, cursor = 0;

		while(i < items.Length && randomValue >= cursor) {
			cursor += weights[i];
			++i;
		}

		if (i < items.Length) {
			Instantiate (items[i], spawn.position, Quaternion.Euler (0.0f, 0.0f, 0.0f));
		}
	}
}
