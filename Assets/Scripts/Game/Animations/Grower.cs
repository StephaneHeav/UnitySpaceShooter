using UnityEngine;
using System.Collections;

public class Grower : MonoBehaviour {
	public float speed = 1f;
	public float limit = 25f;

	void FixedUpdate () {
		if (transform.localScale.x < limit) {
			transform.localScale += new Vector3(speed, 0, speed);
		}
	}
}