using UnityEngine;
using System.Collections;

public class SpecialMover : MonoBehaviour {
	public float speed = 30;
	private Trajectory trajectory = null;
	
	public void Update() {
		if (trajectory != null) {
			transform.position = trajectory.GetNextPosition (transform.position, Time.deltaTime, speed);
		}
	}

	public void SetTrajectory (Trajectory newPattern) {
		trajectory = newPattern;
	}
}
