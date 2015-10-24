using UnityEngine;
using System.Collections;

public class SpecialMover : MonoBehaviour {
	public float speed = 30;
	private Trajectory trajectory = null;

	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}

	public void Update() {
		if (trajectory != null) {
			transform.position = trajectory.GetNextPosition (transform.position, Time.deltaTime, speed);
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}

	public void SetTrajectory (Trajectory newPattern) {
		trajectory = newPattern;
	}
}
