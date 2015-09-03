using UnityEngine;
using System.Collections;

public class SpecialMover : MonoBehaviour {
	public float speed = 30;
	private Pattern pattern = null;
	
	public void Update() {
		if (pattern != null) {
			transform.position = pattern.GetNextPosition (transform.position, speed * Time.deltaTime);
		}
	}

	public void SetPattern (Pattern newPattern) {
		pattern = newPattern;
	}
}
