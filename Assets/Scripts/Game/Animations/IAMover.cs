using UnityEngine;
using System.Collections;

public class IAMover : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void DodgeBullet () {
		GameObject[] shots = GameObject.FindGameObjectsWithTag("Shot");
		int i = shots.Length - 1, lower;
		int[] moy = new int[15] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

		for (; i >= 0; --i) {
			if (shots[i].transform.position.z > transform.position.z + 1) {
				//moy[(int) Mathf.Floor(shots[i].transform.position.x)] += 1 * (transform.position.z - shots[i].transform.position.z);
			}
		}

		lower = moy[moy.Length - 1];
		for (i = moy.Length - 2; i >= 0; --i) {
			if (lower > moy[i]) {
				lower = moy[i];
			}
		}

		transform.position = new Vector3 (lower, 0, transform.position.z);
	}
}
